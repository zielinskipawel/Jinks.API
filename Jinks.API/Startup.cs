using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer3.AccessTokenValidation;
using Jinks.API.Attributes;
using Jinks.API.Models.Converters;
using Jinks.API.Models.Converters.Mapping;
using Jinks.Repository;
using Jinks.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.Builder;
using Owin;
using Swashbuckle.AspNetCore.Swagger;

namespace Jinks.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IProductsRepository, ProductsRepository>();
      services.AddSingleton<IProductConverter, ProductConverter>();
      services.AddScoped<IAuthorizationFilter, ClaimRequirementFilter>();
      services.AddScoped<Claim, Claim>();

      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new ProductProfile());
      });

      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddSwaggerGen(c =>
      {
        c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "", Name = "Authorization", Type = "apiKey" });
        c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
        {
          { "Bearer", Enumerable.Empty<string>() },
        });
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {

      app.UseSwagger();
      app.UseOwin(setup => setup(next =>
      {
        AppBuilder owinAppBuilder = new AppBuilder();

        IdentityServerBearerTokenAuthenticationOptions authenticationOptions = new IdentityServerBearerTokenAuthenticationOptions
        {
          Authority = "https://Skrin/",
          ValidationMode = ValidationMode.ValidationEndpoint,
          RequiredScopes = new[] { "scope" }
        };

        owinAppBuilder.UseIdentityServerBearerTokenAuthentication(authenticationOptions);

        owinAppBuilder.Properties["builder.DefaultApp"] = next;

        return owinAppBuilder.Build<Func<IDictionary<string, object>, Task>>();
      }));
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}

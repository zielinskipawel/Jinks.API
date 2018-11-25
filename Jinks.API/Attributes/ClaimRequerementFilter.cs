using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Jinks.API.Attributes
{
  public class ClaimRequirementFilter : IAuthorizationFilter
  {
    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == "scope");
      if (!hasClaim)
      {
        context.Result = new ForbidResult();
      }
    }
  }
}

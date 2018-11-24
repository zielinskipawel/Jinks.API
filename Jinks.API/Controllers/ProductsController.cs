using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jinks.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Jinks.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
      return new Product[] { new Product(), new Product() };
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      return new Product();
    }

    [HttpPost]
    public void Post([FromBody] Product value)
    {
    }

    [HttpPut("{id}")]
    public void Put(long id, [FromBody] ProductPut value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(long id)
    {
    }
  }
}

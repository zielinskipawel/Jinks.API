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
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
      return new Product[] { new Product(), new Product() };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      return new Product();
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Product value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(long id, [FromBody] ProductPut value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(long id)
    {
    }
  }
}

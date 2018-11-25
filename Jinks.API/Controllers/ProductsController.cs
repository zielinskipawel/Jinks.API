using System;
using System.Collections.Generic;
using Jinks.API.Attributes;
using Jinks.API.Models.Converters;
using Jinks.API.Models.Dto;
using Jinks.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jinks.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductsRepository _repository;
    private readonly IProductConverter _converter;

    public ProductsController(IProductsRepository repository, IProductConverter converter)
    {
      _repository = repository;
      _converter = converter;
    }

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
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ClaimRequirement]
    public ActionResult<Product> Post(Models.Dto.Product product)
    {
      if (!ModelState.IsValid)
      {
        BadRequest(ModelState);
      }
      _repository.AddProduct(_converter.ToRepository(product));
      return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    [ClaimRequirement]
    public void Put(long id, [FromBody] ProductPut value)
    {
      if (!ModelState.IsValid)
      {
        BadRequest();
      }
    }

    [HttpDelete("{id}")]
    [ClaimRequirement]
    public void Delete(long id)
    {
    }
  }
}

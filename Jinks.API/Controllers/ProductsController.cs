﻿using System;
using System.Collections.Generic;
using Jinks.API.Models.Dto;
using Jinks.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Jinks.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsRepository _repository;

    public ProductsController(ProductsRepository repository)
    {
      _repository = repository;
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
    public ActionResult<Product> Post(Models.Dto.Product product)
    {
      _repository.AddProduct(Models.Converters.ProductConverter.ToDto(product));
      return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public void Put(long id, [FromBody] ProductPut value)
    {
      if (!ModelState.IsValid)
      {
        BadRequest();
      }
    }

    [HttpDelete("{id}")]
    public void Delete(long id)
    {
    }
  }
}

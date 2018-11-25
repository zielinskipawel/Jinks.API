using Jinks.Repository.Interfaces;
using Jinks.Repository.Models;
using System;
using System.Diagnostics;

namespace Jinks.Repository
{
  public class ProductsRepository: IProductsRepository
  {
    public long AddProduct(Product product)
    {
      Debug.Print("Add Product to Database");
      return 23;
    }

    public Product GetProduct(long id)
    {
      return new Product();
    }
  }
}

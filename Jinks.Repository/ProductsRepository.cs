using Jink.Repository.Models;
using Jinks.Repository.Interfaces;
using System;
using System.Diagnostics;

namespace Jinks.Repository
{
  public class ProductsRepository: IProductsRepository
  {
    public void AddProduct(Product product)
    {
      Debug.Print("Add Product to Database");
    }
  }
}

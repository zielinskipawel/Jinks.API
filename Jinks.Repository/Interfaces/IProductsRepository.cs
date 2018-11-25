using Jinks.Repository.Models;

namespace Jinks.Repository.Interfaces
{
  public interface IProductsRepository
  {
    long AddProduct(Product product);
    Product GetProduct(long id);
  }
}

using Jinks.Repository.Models;

namespace Jinks.Repository.Interfaces
{
  public interface IProductsRepository
  {
    void AddProduct(Product product);
  }
}

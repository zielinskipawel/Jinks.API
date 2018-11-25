using Jinks.API.Models.Dto;

namespace Jinks.API.Models.Converters
{
  public interface IProductConverter
  {
    ProductPost ToDtoPost(Jinks.Repository.Models.Product productRepo);
    Product ToDto(Jinks.Repository.Models.Product productRepo);
    Jinks.Repository.Models.Product ToRepository(ProductPost productDto);
  }
}

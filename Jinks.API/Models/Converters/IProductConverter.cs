using Jinks.API.Models.Dto;

namespace Jinks.API.Models.Converters
{
  public interface IProductConverter
  {
    Product ToDto(Jinks.Repository.Models.Product productRepo);
    Jinks.Repository.Models.Product ToRepository(Product productDto);
  }
}

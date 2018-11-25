using AutoMapper;

namespace Jinks.API.Models.Converters.Mapping
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      CreateMap<Repository.Models.Product, Dto.Product>().ReverseMap();
    }
  }
}

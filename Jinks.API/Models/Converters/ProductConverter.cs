using AutoMapper;
using Jinks.API.Models.Dto;

namespace Jinks.API.Models.Converters
{
  public class ProductConverter : IProductConverter
  {
    private readonly IMapper _mapper;
    public ProductConverter(IMapper mapper)
    {
      _mapper = mapper;
    }

    public Product ToDto(Jinks.Repository.Models.Product productRepo)
    {
      Dto.Product result = Mapper.Map<Dto.Product>(productRepo);
      return result;
    }

    public Jinks.Repository.Models.Product ToRepository(Product productDto)
    {
      Repository.Models.Product result = Mapper.Map<Repository.Models.Product>(productDto);
      return result;
    }
  }
}

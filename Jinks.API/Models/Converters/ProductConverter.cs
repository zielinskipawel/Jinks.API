using AutoMapper;
using Jinks.API.Models.Dto;
using Jinks.Repository.Models;

namespace Jinks.API.Models.Converters
{
  public class ProductConverter : IProductConverter
  {
    private readonly IMapper _mapper;
    public ProductConverter(IMapper mapper)
    {
      _mapper = mapper;
    }

    public Dto.Product ToDto(Jinks.Repository.Models.Product productRepo)
    {
      Dto.Product result = _mapper.Map<Dto.Product>(productRepo);
      return result;
    }

    public ProductPost ToDtoPost(Repository.Models.Product productRepo)
    {
      Dto.ProductPost result = _mapper.Map<Dto.ProductPost>(productRepo);
      return result;
    }

    public Jinks.Repository.Models.Product ToRepository(ProductPost productDto)
    {
      Repository.Models.Product result = _mapper.Map<Repository.Models.Product>(productDto);
      return result;
    }
  }
}

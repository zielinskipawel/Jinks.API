using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

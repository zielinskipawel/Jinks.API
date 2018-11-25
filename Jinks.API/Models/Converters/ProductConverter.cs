using Jinks.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinks.API.Models.Converters
{
  public static class ProductConverter
  {
    public static Product ToDto(Jinks.Repository.Models.Product productRepo)
    {
      return new Product();
    }

    public static Jinks.Repository.Models.Product ToDto(Product productDto)
    {
      return new Jinks.Repository.Models.Product();
    }
  }
}

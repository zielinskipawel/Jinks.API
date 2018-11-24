
using System.ComponentModel.DataAnnotations;

namespace Jinks.API.Models.Dto
{
  public abstract class ProductBase
  {
    [Required(AllowEmptyStrings = false)]
    [StringLength(300)]
    public string Name { get; set; }

    [Required]
    [Range(0.1, 10000)]
    public decimal Price { get; set; }
  }
}

using System.ComponentModel.DataAnnotations;

namespace Jinks.API.Models.Dto
{
  public class ProductPost 
  {
    [Required(AllowEmptyStrings = false)]
    [StringLength(300)]
    public string Name { get; set; }

    [Required]
    [Range(double.MinValue, double.MaxValue)]
    public decimal Price { get; set; }
  }
}

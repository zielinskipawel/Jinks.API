using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jinks.API.Tests.Models.Validation
{
  [TestFixture]
  class ProductsValidationTests
  {
    [Test]
    public void Model_when_prop_are_not_set_should_return_validation_error()
    {
      // Arrange
      API.Models.Dto.ProductPost product = new API.Models.Dto.ProductPost();
      // Act
      // Assert
      Assert.IsTrue(ValidateModel(product).Count > 0);
    }

    [Test]
    public void Model_when_all_prop_are_set_should_not_return_validation_error()
    {
      // Arrange
      API.Models.Dto.Product product = new API.Models.Dto.Product { Id = 111, Name = "Product Name", Price = 1.1M };
      // Act
      // Assert
      Assert.IsTrue(ValidateModel(product).Count == 0);
    }

    [Test]
    public void Model_Id_not_set_should_not_return_validation_error()
    {
      // Arrange
      API.Models.Dto.Product product = new API.Models.Dto.Product { Name = "Product Name", Price = 1.1M };
      // Act
      // Assert
      Assert.IsTrue(ValidateModel(product).Count == 0);
    }

    private IList<ValidationResult> ValidateModel(object model)
    {
      var validationResults = new List<ValidationResult>();
      var ctx = new ValidationContext(model, null, null);
      Validator.TryValidateObject(model, ctx, validationResults, true);
      return validationResults;
    }
  }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jinks.API.Tests.Models.Validation
{
  [TestFixture]
  class ProductsValidationTests
  {
    [Test]
    public void Model_Should_return_validation_error_when_model_is_empty()
    {

      API.Models.Dto.Product product = new API.Models.Dto.Product();
      Assert.IsTrue(ValidateModel(product).Count > 0);
    }

    [Test]
    public void test1()
    {

      API.Models.Dto.Product product = new API.Models.Dto.Product { Id = 111, Name = "Product Name", Price = 1.1M };
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

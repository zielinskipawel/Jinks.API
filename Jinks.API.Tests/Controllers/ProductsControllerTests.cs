using AutoFixture;
using AutoFixture.AutoMoq;
using Jinks.API.Controllers;
using Jinks.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jinks.API.Tests.Controllers
{
  [TestFixture]
  class ProductsControllerTests
  {
    private IFixture _mockFixture;
    private Mock<IProductsRepository> _productsRepositoryMock;
    private ProductsController controller;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {

    }

    [SetUp]
    public void Setup()
    {
      _mockFixture = new Fixture().Customize(new AutoMoqCustomization());
      _productsRepositoryMock = _mockFixture.Freeze<Mock<IProductsRepository>>();
      controller = _mockFixture.Create<ProductsController>();
    }

    [Test]
    public void Post_Model_Should_return_badRequest_when_model_is_empty()
    {
    }
  }
}

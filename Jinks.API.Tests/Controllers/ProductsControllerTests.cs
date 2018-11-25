﻿using Jinks.API.Controllers;
using Jinks.API.Models.Converters;
using Jinks.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace Jinks.API.Tests.Controllers
{
  [TestFixture]
  class ProductsControllerTests
  {
    private Mock<IProductsRepository> _productsRepositoryMock;
    private Mock<IProductConverter> _productsConverterMock;
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
      _productsRepositoryMock = new Mock<IProductsRepository>();
      _productsConverterMock = new Mock<IProductConverter>();
      controller = new ProductsController(_productsRepositoryMock.Object, _productsConverterMock.Object);
    }

    [Test]
    public void Post_Model_Should_execute_exactly_one_time()
    {
      // Arrange
      API.Models.Dto.Product product = new API.Models.Dto.Product();
      // Act
      var result = controller.Post(product);
      // Assert
      _productsRepositoryMock.Verify(x => x.AddProduct(It.IsAny<Jinks.Repository.Models.Product>()), Times.Once());
      _productsConverterMock.Verify(x => x.ToRepository(It.IsAny<Jinks.API.Models.Dto.Product>()), Times.Once());
    }
  }
}

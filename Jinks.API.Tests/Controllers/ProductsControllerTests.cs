using Jinks.API.Controllers;
using Jinks.Repository.Interfaces;
using Moq;
using NUnit.Framework;


namespace Jinks.API.Tests.Controllers
{
  [TestFixture]
  class ProductsControllerTests
  {
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
      _productsRepositoryMock = new Mock<IProductsRepository>();
      controller = new ProductsController(_productsRepositoryMock.Object);
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
    }
  }
}

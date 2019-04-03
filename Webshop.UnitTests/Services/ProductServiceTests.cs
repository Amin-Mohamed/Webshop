using NUnit.Framework;
using Webshop.Models;
using Webshop.Services;
using FakeItEasy;
using Webshop.Repositories;

namespace Webshop.UnitTests.Services
{
    public class ProductServiceTests
    {
        private IProductRepository productRepository;
        private ProductService productService;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<IProductRepository>();
            this.productService = new ProductService(productRepository);
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromRepository()
        {
            // Arrange
            const int Id = 20;
            var productItem = new Product
            {
                Id = Id,
                Title = "car",
                Description = "BWM",
                Price = 1300,
                Image = null
            };

            A.CallTo(() => this.productRepository.Get(Id)).Returns(productItem);

            // Act
            var result = this.productService.Get(Id);

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }
    }
}

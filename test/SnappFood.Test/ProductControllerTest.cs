using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SnappFood.API.Controllers;
using SnappFood.Core;
using SnappFood.Core.Entities;
using SnappFood.Model;
using SnappFood.Service;

namespace SnappFood.Test
{
    public class ProductControllerTest
    {
        private IUnitOfWork _unitOfWork;
        private IReadOnlyRepository<Product> _productReadOlnyRepository;
        private IProductService _productService;
        private ProductController _productController;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = new FakeUnitOfWork();
            _productService = new ProductService(_unitOfWork, _productReadOlnyRepository);
            _productController = new ProductController(_productService);
        }

        [Test]
        public async Task It_should_create_a_new_product()
        {
            // arrange
            var productToCreate = new ProductToCreateDto { Title = "Pen", Price = 800000, Discount = 20 };

            // act
            var actualResult = await _productController.CreateProduct(productToCreate);

            // assert
            var entity = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == 1);
            entity.Should().BeEquivalentTo(productToCreate);
        }

        [Test]
        public async Task It_should_not_create_duplicate_product_with_same_title()
        {
            // arrange
            var productToCreate = new ProductToCreateDto { Title = "Pen", Price = 800000, Discount = 20 };

            // act
            await _productController.CreateProduct(productToCreate);
            var actualResult = await _productController.CreateProduct(productToCreate);

            // assert
            actualResult.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("There is a product with this title.");
        }
    }
}
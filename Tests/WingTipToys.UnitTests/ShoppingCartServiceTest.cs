using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NSubstitute;
using WingTipToys.Models;
using WingTipToys.Service;
using WingTipToys.Service.Interfaces;

namespace WingTipToys.UnitTests
{
    public class ShoppingCartServiceTest
    {
        // Service under test
        private IShoppingCartService _shoppingCartService;

        // Dependencies
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            // Substitute dependency
            _productService = Substitute.For<IProductService>();

            // Instantiate service under test
            _shoppingCartService = new ShoppingCartService(_productService);
        }

        [Test]
        public void AddItemWithValidProductTest()
        {
            // Arrange
            var guid = new Guid();
            var expectedProduct = new Product
            {
                Id = 1,
                Name = "Testing",
                UnitPrice = 123.45m,
                ImageUrl = "Url",
                Type = ProductType.Cars
            };
            var products = new List<Product>() { expectedProduct };
            _productService.GetProducts().ReturnsForAnyArgs(products);

            // Act
            var actuals = _shoppingCartService.AddProduct(guid, expectedProduct.Id);

            // Assert
            NUnit.Framework.Assert.IsTrue(actuals.Items.Any(i => i.ProductItem.Id == expectedProduct.Id));
        }

        [Test]
        public void AddItemWithInValidProductTest()
        {
            // Arrange
            var guid = new Guid();
            var invalidProductId = 123;
            var product = new Product
            {
                Id = 1,
                Name = "Testing",
                UnitPrice = 123.45m,
                ImageUrl = "Url",
                Type = ProductType.Cars
            };
            var products = new List<Product>() { product };
            _productService.GetProducts().ReturnsForAnyArgs(products);

            // Act
            //var actuals = _shoppingCartService.AddProduct(guid, invalidProductId);
            var ex = Assert.Throws<ArgumentException>(() => _shoppingCartService.AddProduct(guid, invalidProductId));

            // now we can test the exception itself
            Assert.That(ex.Message == $"Could not find product with Id {invalidProductId}");
        }
    }
}
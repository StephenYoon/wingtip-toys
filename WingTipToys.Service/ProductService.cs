using System;
using System.Collections.Generic;
using WingTipToys.DataAccess.Interfaces;
using WingTipToys.Models;
using WingTipToys.Service.Interfaces;

namespace WingTipToys.Service
{
    /// <summary>
    /// Product Service providing access to the data layer and additionally providing
    /// any handling and checking of the data for anyone consuming this service.
    /// </summary>
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(ProductType? productType = null)
        {
            if (productType.HasValue)
            {
                return _productRepository.GetAllByType(productType.Value);
            }

            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}

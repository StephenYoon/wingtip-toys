using System;
using System.Collections.Generic;
using WingTipToys.Models;

namespace WingTipToys.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(ProductType? productType = null);

        public Product GetById(int id);
    }
}

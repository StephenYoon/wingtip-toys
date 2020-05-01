using System.Collections.Generic;
using WingTipToys.Models;

namespace WingTipToys.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllByType(ProductType productType);

        Product GetById(int id);
    }
}

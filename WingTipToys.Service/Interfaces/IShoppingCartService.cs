using System;
using System.Collections.Generic;
using WingTipToys.Models;

namespace WingTipToys.Service.Interfaces
{
    public interface IShoppingCartService
    {
        ShoppingCart GetShoppingCart(Guid id);

        ShoppingCart AddProduct(Guid id, int productId);

        ShoppingCart RemoveProduct(Guid id, int productId);
    }
}

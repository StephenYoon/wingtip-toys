using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WingTipToys.Models;
using WingTipToys.Service.Interfaces;

namespace WingTipToys.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IProductService _productService;
        private List<ShoppingCart> _shoppingCarts;

        // TODO: Add logger service to log scenarios where needed.
        public ShoppingCartService(IProductService productService)
        {
            _productService = productService;

            // To minimize null checks, instantiate with a new list
            _shoppingCarts = new List<ShoppingCart>();
        }

        public ShoppingCart GetShoppingCart(Guid id)
        {
            var cart = _shoppingCarts.FirstOrDefault(c => c.id.Equals(id));
            if (cart == null)
            {
                cart = new ShoppingCart(id);
                _shoppingCarts.Add(cart);
            }

            return cart;
        }

        public ShoppingCart AddProduct(Guid id, int productId)
        {
            var cart = _shoppingCarts.FirstOrDefault(c => c.id.Equals(id));
            if (cart == null)
            {
                cart = new ShoppingCart(id);
                _shoppingCarts.Add(cart);
            }

            var product = _productService.GetProducts().FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                cart.AddItem(product);
            }
            else
            {
                throw new ArgumentException($"Could not find product with Id {productId}");
            }

            return cart;
        }

        public ShoppingCart RemoveProduct(Guid id, int productId)
        {
            throw new NotImplementedException();
        }
    }
}

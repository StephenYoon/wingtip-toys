using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WingTipToys.Models
{
    /// <summary>
    /// Class representing a shopping cart.
    /// Holds products and their quantity.
    /// </summary>
    public class ShoppingCart
    {
        public Guid id { get; set; }

        public List<ShoppingCartItem> Items { get; set; }

        public ShoppingCart(Guid id)
        {
            this.id = id;

            // To minimize null checks, instantiate with a new list
            Items = new List<ShoppingCartItem>();
        }

        public void AddItem(Product product)
        {
            var foundProduct = Items.FirstOrDefault(i => i.ProductItem.Id == product.Id);
            if (foundProduct != null)
            {
                foundProduct.Quantity++;
            }
            else
            {
                Items.Add(new ShoppingCartItem { ProductItem = product, Quantity = 1 });
            }
        }
    }
}

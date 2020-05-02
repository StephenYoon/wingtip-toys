using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WingTipToys.Models;
using WingTipToys.Service.Interfaces;

namespace WingTipToys.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // GET: api/ShoppingCart/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var cart = _shoppingCartService.GetShoppingCart(id);
            return Ok(cart);
        }

        // POST: api/ShoppingCart/5
        [HttpPost("{id}")]
        public IActionResult Post(Guid id, [FromBody] int productId)
        {
            var cart = _shoppingCartService.AddProduct(id, productId);
            return Ok(cart);
        }

        // DELETE: api/ShoppingCart/5/1234567
        [HttpDelete("{id}/{productId}")]
        public IActionResult Delete(Guid id, int productId)
        {
            var cart = _shoppingCartService.RemoveProduct(id, productId);
            return Ok(cart);
        }
    }
}

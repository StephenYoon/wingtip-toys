using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingTipToys.Models;
using WingTipToys.Service.Interfaces;

namespace WingTipToys.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            var results = _productService.GetProducts();
            return Ok(results);
        }

        // GET: api/Products/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var results = _productService.GetById(id);
            return Ok(results);
        }

        // GET: api/Products/Type/1
        [HttpGet("Type/{productTypeId}")]
        public IActionResult GetByProductType(int productTypeId)
        {
            var results = _productService.GetProducts((ProductType)productTypeId);
            return Ok(results);
        }
    }
}

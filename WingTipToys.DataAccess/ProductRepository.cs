﻿using System;
using System.Collections.Generic;
using System.Linq;
using WingTipToys.DataAccess.Interfaces;
using WingTipToys.Models;

namespace WingTipToys.DataAccess
{
    /// <summary>
    /// Product Repository class providing access to our application data.
    /// TODO: Currently mock data, but we can install EntityFramework and connect 
    ///       to SQL Server as a data source.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            // TODO: install EntityFramework to make a connection to a SQL Server to replace mock data.
            return MockData();
        }

        public IEnumerable<Product> GetAllByType(ProductType productType)
        {
            var data = MockData();
            var filteredData = data.Where(entity => entity.Type == productType);

            return filteredData;
        }

        public Product GetById(int id)
        {
            var data = MockData();
            var filteredData = data.FirstOrDefault(entity => entity.Id == id);

            // TODO: possibly check to see if more than one entity is found and log it or throw exception if necessary.

            return filteredData;
        }

        private IEnumerable<Product> MockData()
        {
            var data = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Jeep Wrangler Rubicon",
                    UnitPrice = 67.50m,
                    ImageUrl = "https://www.wallpaperup.com/uploads/wallpapers/2014/07/10/393467/f81e3e63d16076d51688e9802c573f79.jpg",
                    Type = ProductType.Cars
                },
                new Product
                {
                    Id = 2,
                    Name = "Toyota Supra",
                    UnitPrice = 63.21m,
                    ImageUrl = "https://cnet2.cbsistatic.com/img/rZMNDzGaH70YeWkRQrTfPl_H--Y=/940x0/2020/02/12/99823121-7ef6-4d35-b781-ef97aa11e5ff/2021-toyota-supra-2-0-promo.jpg",
                    Type = ProductType.Cars
                },
                new Product 
                { 
                    Id = 3, 
                    Name = "Chevy Camaro SS", 
                    UnitPrice = 25.99m, 
                    ImageUrl = "https://static.carsdn.co/cldstatic/wp-content/uploads/2020-Chevrolet-Camaro-SS-OEM.jpg", 
                    Type = ProductType.Cars 
                },
                new Product 
                { 
                    Id = 4,
                    Name = "Ford Mustang 5.0 toy", 
                    UnitPrice = 20.99m, 
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61kRyEKfzUL._AC_SX425_.jpg", 
                    Type = ProductType.Cars 
                },
                new Product 
                { 
                    Id = 5,
                    Name = "Dodge Challender Hellcat toy", 
                    UnitPrice = 28.99m, 
                    ImageUrl = "https://www.dhresource.com/0x0/f2/albu/g8/M01/4E/11/rBVaVFyVormAGBQWAAEUtQEx870249.jpg", 
                    Type = ProductType.Cars
                },
                new Product 
                { 
                    Id = 6,
                    Name = "Tennis racket", 
                    UnitPrice = 50.99m, 
                    ImageUrl = "https://www.e-tennis.com/media/catalog/product/cache/1/thumbnail/800x800/9df78eab33525d08d6e5fb8d27136e95/w/r/wr014011_wilson-blade-100l-v7-0-tennis-racquet.jpg", 
                    Type = ProductType.Sports 
                },
                new Product 
                { 
                    Id = 7,
                    Name = "Tennis balls", 
                    UnitPrice = 3.99m, 
                    ImageUrl = "https://www.gophersport.com/cmsstatic/img/453/G-51109-PressurelessTennisBalls-ce-3-clean.jpg?medium", 
                    Type = ProductType.Sports 
                },
                new Product
                {
                    Id = 8,
                    Name = "Bang: The Dice Game", 
                    UnitPrice = 15.99m, 
                    ImageUrl = "https://media.miniaturemarket.com/media/catalog/product/d/v/dvg9112_2.jpg", 
                    Type = ProductType.Boardgames 
                },
                new Product
                { 
                    Id = 9,
                    Name = "Avalon",
                    UnitPrice = 12.99m, 
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1704/1809/products/6a9be3ba0badcb7369aa8a6e4b746048fc23334d_500x.jpg?v=1559261133", 
                    Type = ProductType.Boardgames 
                },
                new Product 
                { 
                    Id = 10,
                    Name = "Battleship", 
                    UnitPrice = 7.99m, 
                    ImageUrl = "https://cf.geekdo-images.com/imagepage/img/nk5MSBn_TZs-vTtu2KrY2xWBfok=/fit-in/900x600/filters:no_upscale()/pic1293565.jpg", 
                    Type = ProductType.Boardgames 
                }
            };

            return data;
        }
    }
}

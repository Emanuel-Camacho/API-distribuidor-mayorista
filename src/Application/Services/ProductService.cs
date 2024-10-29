using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepostory;
        public ProductService(IProductRepository productRepository)
        {
            _productRepostory = productRepository;
        }

        public List<ProductDto> GetProducts()
        {

            var products = _productRepostory.GetBooks();

            return products
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductBrand = product.ProductBrand,
                    ProductDetail = product.ProductDetail,
                    ProductPrice = product.ProductPrice,
                    ImageUrl = product.ImageURL
                })
                .ToList();
        }

        public int AddProduct(ProductDto productDto)
        {
            return _productRepostory.AddProduct(new Product
            {
                ProductName = productDto.ProductName,
                ProductBrand = productDto.ProductBrand,
                ProductDetail = productDto.ProductDetail,
                ProductPrice = productDto.ProductPrice,
                ImageUrl = productDto.ImageUrl
            });
        }

        public void DeleteProduct(int id)
        {
            _productRepostory.DeleteProduct(id);
        }


    }
}
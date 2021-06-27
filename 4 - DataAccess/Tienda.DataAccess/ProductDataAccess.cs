using System;
using System.Linq;
using System.Collections.Generic;
using Dtos;
using Tienda.Interfaces;
using Tienda.Dto;
using Tienda.Dapper;

namespace Persistencia
{
    public class ProductDataAccess : IProductLogic
    {
        private List<Product>  Products { get; }

        public ProductDataAccess()
        {
            Products = new List<Product>();
        }

        public void CreateProduct(Product product)
        {
            if (Products.Any(p => p.Id == product.Id))
            {
                throw new Exception("Producto duplicado");
            }
            Products.Add(product);
        }
        
        public bool DeleteProduct(int id)
        {
            var product = GetProduct(id);
            return Products.Remove(product);
        }

        public void UpdateProduct(Product newProductData)
        {
            var currentProduct = GetProduct(newProductData.Id);
            if (currentProduct == null)
            {
                throw new Exception("Producto no encontrado");
            }

            currentProduct.Name = newProductData.Name;
            currentProduct.Description = newProductData.Description;
            currentProduct.Price = newProductData.Price;
        }

        public int ValidateUserInput(int id, string type)
        {
            return ValidateUserInput(id, type);
        }

        public List<Product> GetProductsPaginated(int pageIndex, int pageSize, string orderBy, int orderDirection, string search, int category)
        {
            return GetProductsPaginated(pageIndex, pageSize, orderBy, orderDirection, search, category);
        }

        public List<Product> ListProducts()
        {
            return Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();
            
    }

        public Product GetProduct(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Category> GetCategories()
        {
            return GetCategories();
        }

        public List<Product> GetProductsByCategory(int category, string search)
        {
            return GetProductsByCategory(category, search);
        }
    }
}
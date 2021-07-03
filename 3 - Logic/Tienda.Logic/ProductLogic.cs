using Dtos;
using Persistencia;
using System;
using System.Collections.Generic;
using Tienda.Dapper;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class ProductLogic: IProductLogic
    {
        public IProductLogic DataAccess { get; }

        public ProductLogic()
        {
            this.DataAccess = new ProductDapper();
        }
        
        public void CreateProduct(Product product)
        {
            this.DataAccess.CreateProduct(product);
        }
        
        public List<Product> ListProducts()
        {
            return this.DataAccess.ListProducts();
        }
        
        public bool DeleteProduct(int id)
        {
            if(DataAccess.GetProduct(id) != null)
            {
                return DataAccess.DeleteProduct(id);
            }
            return false;
        }

        public void UpdateProduct(Product newProductData)
        {
            DataAccess.UpdateProduct(newProductData);
        }

        public Product GetProduct(int id)
        {
            return DataAccess.GetProduct(id);
        }

        public ProductsWithPageCount GetProductsPaginated(int pageIndex, int pageSize, string orderBy, int orderDirection, string search, int category)
        {
            return this.DataAccess.GetProductsPaginated(pageIndex, pageSize, orderBy, orderDirection, search, category);
        }

        public int ValidateUserInput(int id, string type)
        {
            return DataAccess.ValidateUserInput(id, type);
        }

        public List<Category> GetCategories()
        {
            return DataAccess.GetCategories();
        }

        public List<Product> GetProductsByCategory(int category, string search)
        {
            return DataAccess.GetProductsByCategory(category, search);
        }
    }
}

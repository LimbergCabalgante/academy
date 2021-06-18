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
        public IProductLogic dataAccess { get; }

        public ProductLogic()
        {
            this.dataAccess = new DapperDataAccess();
        }
        
        public void CreateProduct(Product product)
        {
            this.dataAccess.CreateProduct(product);
        }
        
        public List<Product> ListProducts()
        {
            return this.dataAccess.ListProducts();
        }
        
        public bool DeleteProduct(int id)
        {
            if(dataAccess.GetProduct(id) != null)
            {
                return dataAccess.DeleteProduct(id);
            }
            return false;
        }

        public void UpdateProduct(Product newProductData)
        {
            dataAccess.UpdateProduct(newProductData);
        }

        public Product GetProduct(int id)
        {
            return dataAccess.GetProduct(id);
        }

        public List<Product> GetProductsPaginated(int pageIndex, int pageSize, int order, int category)
        {
            return this.dataAccess.GetProductsPaginated(pageIndex, pageSize, order, category);
        }

        public int ValidateUserInput(int id, string type)
        {
            return dataAccess.ValidateUserInput(id, type);
        }
    }
}

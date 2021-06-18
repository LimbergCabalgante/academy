using Dtos;
using System.Collections.Generic;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IProductLogic
    {
        Product GetProduct(int id);

        public List<Product> GetProductsPaginated(int pageIndex, int pageSize, int order, int category);

        void CreateProduct(Product product);

        List<Product> ListProducts();
        
        bool DeleteProduct(int id);

        void UpdateProduct(Product newProductData);

        public int ValidateUserInput(int id, string type);
    }

}
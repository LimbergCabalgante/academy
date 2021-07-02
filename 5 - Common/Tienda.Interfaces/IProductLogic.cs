using Dtos;
using System.Collections.Generic;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IProductLogic
    {
        Product GetProduct(int id);

        public ProductsWithPageCount GetProductsPaginated(int pageIndex, int pageSize, string orderBy, int orderDirection, string search, int category);

        void CreateProduct(Product product);

        List<Product> ListProducts();
        
        bool DeleteProduct(int id);

        void UpdateProduct(Product newProductData);

        public int ValidateUserInput(int id, string type);

        public List<Category> GetCategories();

        public List<Product> GetProductsByCategory(int category, string search);
    }

}
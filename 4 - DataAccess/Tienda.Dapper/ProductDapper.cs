using Dapper;
using Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Dapper
{
    public class ProductDapper : IProductLogic
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=TiendaV2;Integrated Security=True";

        public void CreateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO dbo.Products (Name, Description, Price, StatusId, CreatedDate, CategoryId, ImageUrl) VALUES (@Name, @Description, @Price, @StatusId, @CreatedDate, @CategoryId, @ImageUrl)", 
                    new { 
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        StatusId = product.Status,
                        CreatedDate = DateTime.Now,
                        CategoryId = product.CategoryId,
                        ImageUrl = product.ImageUrl
                    });
            }
        }

        public bool DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute("DELETE FROM dbo.Products WHERE Id=@ProductId", new { ProductId = id }) > 0;
            }
        }

        public Product GetProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return ProductMapper(connection.QueryFirst("SELECT * FROM dbo.Products WHERE Id=@ProductId", new { ProductId = id }));
            }
        }

        public List<Product> ListProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query("SELECT * FROM dbo.Products").Select(ProductMapper).AsList();
            }
        }

        public void UpdateProduct(Product newProductData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("UPDATE dbo.Products SET Name=@Name, Description=@Description, Price=@Price, StatusId=@StatusId, CreatedDate=@CreatedDate, CategoryId=@CategoryId, ImageUrl=@ImageUrl WHERE Id=@ProductId",
                    new
                    {
                        ProductId = newProductData.Id,
                        Name = newProductData.Name,
                        Description = newProductData.Description,
                        Price = newProductData.Price,
                        StatusId = newProductData.Status,
                        CreatedDate = DateTime.Now,
                        CategoryId = newProductData.CategoryId,
                        ImageUrl = newProductData.ImageUrl
                    });
            }
        }

        public ProductsWithPageCount GetProductsPaginated(int pageIndex, int pageSize, string orderBy, int orderDirection, string search, int category)
        {
            var result = new ProductsWithPageCount();

            var dynamic = new DynamicParameters();
            dynamic.Add("@PageIndex", pageIndex);
            dynamic.Add("@PageSize", pageSize);
            dynamic.Add("@OrderBy", orderBy);
            dynamic.Add("@OrderDirection", orderDirection);
            dynamic.Add("@Search", search);
            dynamic.Add("@Category", category);
            dynamic.Add("@ProductCount", 0, DbType.Int32, ParameterDirection.Output);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                result.Products = connection.Query("dbo.Products_GetProductsPaginated2", dynamic, commandType: CommandType.StoredProcedure).Select(ProductMapper).AsList();
                result.ProductCount = dynamic.Get<int>("ProductCount");
            }
            return result;
        }

        public int ValidateUserInput(int id, string type)
        {
            switch (type) {

                case "category":
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        return connection.QueryFirst<int>("SELECT CASE WHEN EXISTS(SELECT Id FROM dbo.Categories WHERE @id = Id) THEN 1 ELSE 0 END", new { id = id });
                    }

                case "status":
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        return connection.QueryFirst<int>("SELECT CASE WHEN EXISTS(SELECT ProductStatusId FROM dbo.ProductStatus WHERE @id = ProductStatusId) THEN 1 ELSE 0 END", new { id = id });
                    }

                case "orderlines":
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        return connection.QueryFirst<int>("SELECT CASE WHEN EXISTS(SELECT ProductId FROM dbo.OrderLines WHERE @id = ProductId) THEN 1 ELSE 0 END", new { id = id });
                    }

                default: 
                    return 0;

            }

        }

        public List<Category> GetCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Category>("SELECT * FROM dbo.Categories").AsList();
            }
        }

        public List<Product> GetProductsByCategory(int category, string search)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query("SELECT * FROM dbo.Products WHERE (([Name] LIKE @Search + '%') OR (@Search = '') OR @Search = 'null' OR (@Search is null)) AND ((CategoryId = @Category) OR (@Category = 0) OR (@Category is null))", new {
                    Category = category,
                    Search = search
                }).Select(ProductMapper).AsList();
            }
        }

        private Product ProductMapper(dynamic dbProduct)
        {
            if(dbProduct != null)
            {
                return new Product 
                {
                    Id = dbProduct.Id,
                    Name = dbProduct.Name,
                    Description = dbProduct.Description,
                    Price = dbProduct.Price,
                    CreatedDate = dbProduct.CreatedDate,
                    Status = (ProductStatus)dbProduct.StatusId,
                    CategoryId = dbProduct.CategoryId,
                    ImageUrl = dbProduct.ImageUrl
                };
            }
            return null;
        }
    }
}

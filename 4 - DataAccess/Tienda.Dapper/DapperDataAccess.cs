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
    public class DapperDataAccess : IProductLogic
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

        public List<Product> GetProductsPaginated(int pageIndex, int pageSize, string orderBy, int orderDirection, int category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query("dbo.Products_GetProductsPaginated",
                    new
                    {
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        OrderBy = orderBy,
                        OrderDirection = orderDirection,
                        Category = category
                    }, 
                    commandType: CommandType.StoredProcedure).Select(ProductMapper).AsList();
            }
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

using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Dapper
{
    public class OrderDapper : IOrderLogic
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=TiendaV2;Integrated Security=True";

        public List<Order> GetOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Order>("SELECT * FROM dbo.Orders ORDER BY CreatedDate DESC").AsList();
            }
        }

        public void CreateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO dbo.Orders (UserId, StatusId, TotalPrice, UserFullName, CreatedDate) VALUES (@UserId, @StatusId, @TotalPrice, @UserFullName, @CreatedDate)",
                    new
                    {
                        UserId = order.UserId,
                        StatusId = 1,
                        TotalPrice = order.TotalPrice,
                        UserFullName = order.UserFullName,
                        CreatedDate = DateTime.Now
                    });
            }
        }

        public void UpdateOrderStatus(int id, int statusId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("UPDATE dbo.Orders SET StatusId=@StatusId WHERE Id=@Id",
                    new
                    {
                        StatusId = statusId,
                        Id = id
                    });
            }
        }
    }
}

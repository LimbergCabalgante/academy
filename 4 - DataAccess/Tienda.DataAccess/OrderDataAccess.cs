using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.DataAccess
{
    public class OrderDataAccess : IOrderLogic
    {
        private List<Order> Orders { get; }

        public OrderDataAccess()
        {
            Orders = new List<Order>();
        }

        public List<Order> GetOrders()
        {
            return GetOrders();
        }

        public void CreateOrder(Order order)
        {
            Orders.Add(order);
        }

        public void UpdateOrderStatus(int id, int orderStatus)
        {
            UpdateOrderStatus(id, orderStatus);
        }
    }
}

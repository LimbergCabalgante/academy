using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IOrderLogic
    {
        public List<Order> GetOrders();
        void CreateOrder(Order order);
        void UpdateOrderStatus(int id, int statusId);
    }
}

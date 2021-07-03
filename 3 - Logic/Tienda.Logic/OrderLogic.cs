using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dto;
using Tienda.Dapper;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class OrderLogic: IOrderLogic
    {
       public IOrderLogic DataAccess { get; }
       public OrderLogic()
       {
           this.DataAccess = new OrderDapper();
       }

       public List<Order> GetOrders()
       {
           return this.DataAccess.GetOrders();
       }

       public void CreateOrder(Order order)
       {
           this.DataAccess.CreateOrder(order);
       }

       public void UpdateOrderStatus(int id, int statusId)
       {
           this.DataAccess.UpdateOrderStatus(id, statusId);
       }
    }
}

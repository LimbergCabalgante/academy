using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Order> GetOrders([FromServices] IOrderLogic orderLogic)
        {
            var orders = orderLogic.GetOrders();
            return Ok(orders);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order order, [FromServices] IOrderLogic orderLogic)
        {
            orderLogic.CreateOrder(new Order
            {
                UserId = order.UserId,
                StatusId = order.StatusId,
                TotalPrice = order.TotalPrice,
                UserFullName = order.UserFullName
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Order order, [FromServices] IOrderLogic orderLogic)
        {
            var id = order.Id;
            var statusId = order.StatusId;
            orderLogic.UpdateOrderStatus(id, statusId);
            return Ok();
        }
    }
}

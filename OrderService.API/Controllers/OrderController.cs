using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.BL.Abstraction;
using OrderService.DAL.Abstraction.Repositories;
using OrderService.DAL.Common;
using OrderService.DAL.Contracts.Responses;
using OrderService.DAL.Entities;

namespace OrderService.API.Controllers
{
    [Route("Order/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrderId")]
        public async Task<OrderResponse> GetOrderId(Guid orderId)
        {
            return await _orderService.GetOrderId(orderId);
        }

        [HttpPost("CreateOrder")]
        public async Task<OrderResponse> CreateOrder([FromBody] int quantityItem)
        {
            return await _orderService.CreateOrder(quantityItem);
        }

        [HttpPut("UpdateOrder")]
        public async Task<OrderResponse> UpdateOrder(Guid orderId, OrderStatus newStatus)
        {
            return await _orderService.UpdateOrder(orderId, newStatus);
        }
        
        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(Guid orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return Ok();
        }
    }
}

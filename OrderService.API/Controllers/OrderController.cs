using Microsoft.AspNetCore.Mvc;
using OrderService.BL.Abstraction;
using OrderService.DAL.Contracts.Requests;
using OrderService.DAL.Contracts.Responses;

namespace OrderService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderSvc _orderService;
        public OrderController(IOrderSvc orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrderId")]
        public async Task<OrderResponse> GetOrderId(Guid orderId)
        {
            return await _orderService.GetOrderId(orderId);
        }

        [HttpPost("CreateOrder")]
        public async Task<OrderResponse> CreateOrder( int quantityItem)
        {
            return await _orderService.CreateOrder(quantityItem);
        }

        [HttpPut("ChangeOrderStatus")]
        public async Task<OrderResponse> ChangeOrderStatus([FromBody] ChangeOrderStatusRequest request)
        {
            return await _orderService.ChangeOrderStatus(request);
        }

        [HttpPut("AddItemForOrder")]
        public async Task<OrderResponse> AddItemForOrder([FromBody] AddItemForOrderRequest request)
        {
            return await _orderService.AddItemForOrder(request);
        }
        
        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(Guid orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return Ok();
        }

        [HttpDelete("DeleteItemForOrder")]
        public async Task<ActionResult> DeleteItemForOrder(Guid lineItemId)
        {
            await _orderService.DeleteItemForOrder(lineItemId);
            return Ok();
        }
    }
}

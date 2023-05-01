using Microsoft.AspNetCore.Mvc;
using OrderService.API.Model.Requests;
using OrderService.API.Model.Responces;
using OrderService.Contracts.Abstraction.Services;
using OrderService.Contracts.DTOModels;

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
        public async Task<OrderResponse> GetOrderId(Guid orderHeaderId)
        {
            var orderDto = await _orderService.GetOrderId(orderHeaderId);
            var orderResponse = MapOrderDtoToOrderResponse(orderDto);

            return orderResponse;
        }

        [HttpPost("CreateOrder")]
        public async Task<OrderResponse> CreateOrder(int quantityItem)
        {
            var orderDto = await _orderService.CreateOrder(quantityItem);
            var orderResponse = MapOrderDtoToOrderResponse(orderDto);

            return orderResponse;
        }

        [HttpPut("ChangeOrderStatus")]
        public async Task<OrderResponse> ChangeOrderStatus([FromBody] ChangeOrderStatusRequest changeOrderStatusRequest)
        {
            var changeOrderStatusDto = new ChangeOrderStatusDto
            {
                OrderHeaderId = changeOrderStatusRequest.OrderHeaderId,
                NewStatus = changeOrderStatusRequest.NewStatus
            };

            var orderDto = await _orderService.ChangeOrderStatus(changeOrderStatusDto);
            var orderResponse = MapOrderDtoToOrderResponse(orderDto);

            return orderResponse;
        }

        [HttpPut("AddItemForOrder")]
        public async Task<OrderResponse> AddItemForOrder([FromBody] AddItemForOrderRequest addItemForOrderRequest)
        {
            var addItemForOrderDto = new AddItemForOrderDto
            {
                OrderHeaderId = addItemForOrderRequest.OrderHeaderId,
                QuantityItem = addItemForOrderRequest.QuantityItem,
            };

            var orderDto = await _orderService.AddItemForOrder(addItemForOrderDto);
            var orderResponse = MapOrderDtoToOrderResponse(orderDto);

            return orderResponse;
        }
        
        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(Guid orderHeaderId)
        {
            await _orderService.DeleteOrder(orderHeaderId);
            return Ok();
        }

        [HttpDelete("DeleteItemForOrder")]
        public async Task<ActionResult> DeleteItemForOrder(Guid lineItemId)
        {
            await _orderService.DeleteItemForOrder(lineItemId);
            return Ok();
        }

        private OrderResponse MapOrderDtoToOrderResponse(OrderDto orderDto)
        {
            var orderResponse = new OrderResponse
            {
                OrderHeaderId = orderDto.OrderHeaderId,
                Status = orderDto.Status,
                CreatedDate = orderDto.DateCreated,
                Lines = orderDto.OrderLineItemsDto.Select(o => new LineItemResponse
                {
                    ItemId = o.Id,
                    Qty = o.Quantity
                }).ToList()
            };

            return orderResponse;
        }
    }
}

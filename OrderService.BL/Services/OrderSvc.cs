using OrderService.Contracts.Abstraction.Repositories;
using OrderService.Contracts.Abstraction.Services;
using OrderService.Contracts.DTOModels;

namespace OrderService.BL.Services
{
    public class OrderSvc : IOrderSvc
    {
        private readonly IOrderRepository _orderRepository;
        public OrderSvc(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> CreateOrder(int quantityItem)
        {
            var order = await _orderRepository.CreateOrder(quantityItem);

            return order;
        }

        public async Task<OrderDto> GetOrderId(Guid orderHeaderId)
        {
            var orderDto = await _orderRepository.GetOrderId(orderHeaderId);

            return orderDto;
        }

        public async Task<OrderDto> ChangeOrderStatus(ChangeOrderStatusDto changeOrderStatusDto)
        {
            var orderDto = await _orderRepository.ChangeOrderStatus(changeOrderStatusDto);

            return orderDto;
        }

        public async Task<OrderDto> AddItemForOrder(AddItemForOrderDto addItemForOrderDto)
        {
           var orderDto = await _orderRepository.AddItemLineForOrder(addItemForOrderDto);

            return orderDto;
        }

        public async Task DeleteOrder(Guid orderHeaderId)
        {
             await _orderRepository.DeleteOrder(orderHeaderId);
        }

        public async Task DeleteItemForOrder(Guid lineItemId)
        {
            await _orderRepository.DeleteItemForOrder(lineItemId);
        }
    }
}

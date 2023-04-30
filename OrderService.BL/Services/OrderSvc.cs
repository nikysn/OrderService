using OrderService.BL.Abstraction;
using OrderService.DAL.Abstraction.Repositories;
using OrderService.DAL.Common;
using OrderService.DAL.Contracts.Responses;
using OrderService.DAL.Entities;

namespace OrderService.BL.Services
{
    public class OrderSvc : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderSvc(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> CreateOrder(int quantityItem) 
        {
            if(quantityItem <= 0)
            {
                throw new ArgumentException("Количество должно быть больше нуля");
            }

            var orderEntity = new OrderEntity(quantityItem);

            await _orderRepository.AddOrder(orderEntity);

            var order = MapOrderEntityToOrderResponse(orderEntity);

            return order;
        }

        public async Task<OrderResponse> GetOrderId(Guid orderId)
        {
            var orderEntity = await _orderRepository.GetOrder(orderId);

            var order = MapOrderEntityToOrderResponse(orderEntity);
            return order;
        }

        public async Task<OrderResponse> UpdateOrder(Guid orderId, OrderStatus newStatus)
        {
            var orderEntity = await _orderRepository.GetOrder(orderId);

            if (orderEntity.Header.Status == OrderStatus.Paid ||
                 orderEntity.Header.Status == OrderStatus.InDelivery ||
                 orderEntity.Header.Status == OrderStatus.InDelivery ||
                 orderEntity.Header.Status == OrderStatus.Completed)
            {
                throw new InvalidOperationException("Заказ не может быть отредактирован в текущем статусе");
            }

            orderEntity.Header.Status = newStatus;

            await _orderRepository.SaveChanges();

            var order = MapOrderEntityToOrderResponse(orderEntity);
           

            return order;
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var orderEntity = await _orderRepository.GetOrder(orderId);
            
            if(orderEntity.Header.Status == OrderStatus.InDelivery ||
               orderEntity.Header.Status == OrderStatus.InDelivery ||
               orderEntity.Header.Status == OrderStatus.InDelivery)
            {
                throw new InvalidOperationException("Заказ не может быть удален в текущем статусе");
            }

            await _orderRepository.DeleteOrder(orderEntity);
        }

        private OrderResponse MapOrderEntityToOrderResponse(OrderEntity orderEntity)
        {
            var order = new OrderResponse
            {
                OrderId = orderEntity.Id,
                Status = orderEntity.Header.Status.ToString(),
                CreatedDate = orderEntity.Header.DateCreated.ToString(),
                Lines = orderEntity.OrderLineItemEntities.Select(item => new LineItemResponse { ItemId = item.Id, Qty = item.Quantity }).ToList()
            };

            return order;
        }
    }
}

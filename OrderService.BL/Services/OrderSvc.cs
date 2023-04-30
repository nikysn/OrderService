using OrderService.BL.Abstraction;
using OrderService.DAL.Abstraction.Repositories;
using OrderService.DAL.Common;
using OrderService.DAL.Contracts.Requests;
using OrderService.DAL.Contracts.Responses;
using OrderService.DAL.Entities;

namespace OrderService.BL.Services
{
    public class OrderSvc : IOrderSvc
    {
        private readonly IOrderRepository _orderRepository;
        public OrderSvc(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> CreateOrder(int quantityItem)
        {
            if (quantityItem <= 0)
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

        public async Task<OrderResponse> ChangeOrderStatus(ChangeOrderStatusRequest request)
        {
            var orderEntity = await _orderRepository.GetOrder(request.OrderId);

            CheckOrderStatusCanBeEdition(orderEntity);

            orderEntity.Header.Status = request.NewStatus;

            var order = MapOrderEntityToOrderResponse(orderEntity);

            await _orderRepository.SaveChanges();

            return order;
        }

        public async Task<OrderResponse> AddItemForOrder(AddItemForOrderRequest request)
        {
            var orderEntity = await _orderRepository.GetOrder(request.OrderId);

            CheckOrderStatusCanBeEdition(orderEntity);

            var newItem = new OrderLineItemEntity(orderEntity.Id, request.QuantityItem);
            await _orderRepository.AddItemLineForOrder(newItem);

            var order = MapOrderEntityToOrderResponse(orderEntity);

            return order;
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var orderEntity = await _orderRepository.GetOrder(orderId);

            CheckOrderStatusForDelete(orderEntity);

            await _orderRepository.DeleteOrder(orderEntity);
        }

        public async Task DeleteItemForOrder(Guid lineItemId)
        {
            var lineItemEntity = await _orderRepository.FindItemForOrder(lineItemId);
            var orderEntity = await _orderRepository.FindOrderByItemId(lineItemEntity);

            CheckOrderStatusForDelete(orderEntity);

            await _orderRepository.DeleteItemForOrder(lineItemEntity);
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

        private void CheckOrderStatusCanBeEdition(OrderEntity orderEntity)
        {
            if (orderEntity.Header.Status == OrderStatus.Paid ||
               orderEntity.Header.Status == OrderStatus.InDelivery ||
               orderEntity.Header.Status == OrderStatus.InDelivery ||
               orderEntity.Header.Status == OrderStatus.Completed)
            {
                throw new InvalidOperationException("Заказ не может быть отредактирован в текущем статусе заказа");
            }
        }

        private void CheckOrderStatusForDelete(OrderEntity orderEntity)
        {
            if (orderEntity.Header.Status == OrderStatus.InDelivery ||
              orderEntity.Header.Status == OrderStatus.Delivered ||
              orderEntity.Header.Status == OrderStatus.Completed)
            {
                throw new InvalidOperationException("Действие недопустимо в текущем статусе заказа");
            }
        }
    }
}

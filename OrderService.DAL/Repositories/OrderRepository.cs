using Microsoft.EntityFrameworkCore;
using OrderService.Contracts.Abstraction.Repositories;
using OrderService.Contracts.Common;
using OrderService.Contracts.DTOModels;
using OrderService.DAL.Data;
using OrderService.DAL.Entities;

namespace OrderService.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<OrderDto> CreateOrder(int quantityItem)
        {
            if (quantityItem <= 0)
            {
                throw new ArgumentException("Количество должно быть больше нуля");
            }

            var orderHeaderEntity = new OrderHeaderEntity(quantityItem);
            var orderLineItemEntity = orderHeaderEntity.OrderLineItemEntities.FirstOrDefault();

            await _dataContext.OrderHeaders.AddAsync(orderHeaderEntity);
            await _dataContext.OrdersLineItems.AddAsync(orderLineItemEntity);
            await _dataContext.SaveChangesAsync();

            var orderDto = new OrderDto
            {
                OrderHeaderId = orderHeaderEntity.Id,
                Status = orderHeaderEntity.Status.ToString(),
                DateCreated = orderHeaderEntity.DateCreated.ToString(),
                OrderLineItemsDto = new List<OrderLineItemDto>(),
            };

            var orderLineItemDto = new OrderLineItemDto
            {
                Id = orderLineItemEntity.Id,
                ItemId = orderLineItemEntity.ItemId,
                Quantity = orderLineItemEntity.Quantity,
            };

            orderDto.OrderLineItemsDto.Add(orderLineItemDto);

            return orderDto;
        }

        public async Task<OrderDto> GetOrderId(Guid orderHeaderId)
        {
            var orderHeaderEntity = await GetOrderHeaderById(orderHeaderId);

            var orderDto = MapOrderHeaderToOrderDto(orderHeaderEntity);

            return orderDto;
        }

        public async Task<OrderDto> ChangeOrderStatus(ChangeOrderStatusDto changeOrderStatusDto)
        {
            var orderHeaderEntity = await GetOrderHeaderById(changeOrderStatusDto.OrderHeaderId);

            CheckOrderStatusCanBeEdition(orderHeaderEntity);

            orderHeaderEntity.Status = changeOrderStatusDto.NewStatus;
            await _dataContext.SaveChangesAsync();

            var orderDto = MapOrderHeaderToOrderDto(orderHeaderEntity);
            return orderDto;
        }

        public async Task<OrderDto> AddItemLineForOrder(AddItemForOrderDto addItemForOrderDto)
        {
            var orderHeaderEntity = await GetOrderHeaderById(addItemForOrderDto.OrderHeaderId);

            CheckOrderStatusCanBeEdition(orderHeaderEntity);

            if (addItemForOrderDto.QuantityItem <= 0)
            {
                throw new ArgumentException("Количество должно быть больше нуля");
            }

            var newItem = new OrderLineItemEntity(addItemForOrderDto.OrderHeaderId, addItemForOrderDto.QuantityItem);

            await _dataContext.OrdersLineItems.AddAsync(newItem);
            await _dataContext.SaveChangesAsync();

            var orderDto = await GetOrderId(addItemForOrderDto.OrderHeaderId);
            return orderDto;
        }

        public async Task DeleteOrder(Guid orderHeaderId)
        {
            var orderHeaderEntity = await GetOrderHeaderById(orderHeaderId);

            CheckOrderStatusForDelete(orderHeaderEntity);

            _dataContext.OrderHeaders.Remove(orderHeaderEntity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteItemForOrder(Guid lineItemId)
        {
            var lineItem = await _dataContext.OrdersLineItems.FirstOrDefaultAsync(o => o.Id == lineItemId);

            if (lineItem == null)
            {
                throw new ArgumentException("Товар не найден");
            }

            var orderHeaderEntity = await GetOrderHeaderById(lineItem.OrderHeaderId);

            CheckOrderStatusForDelete(orderHeaderEntity);

            if (orderHeaderEntity.OrderLineItemEntities.Count == 1)
            {
                _dataContext.OrderHeaders.Remove(orderHeaderEntity);
                await _dataContext.SaveChangesAsync();
                return;
            }

            _dataContext.OrdersLineItems.Remove(lineItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        private async Task<OrderHeaderEntity> GetOrderHeaderById(Guid orderHeaderId)
        {
            var orderHeaderEntity = await _dataContext.OrderHeaders
        .Include(o => o.OrderLineItemEntities)
        .FirstOrDefaultAsync(o => o.Id == orderHeaderId);

            if (orderHeaderEntity == null)
            {
                throw new ArgumentException("Заказ не найден");
            }

            return orderHeaderEntity;
        }

        private OrderDto MapOrderHeaderToOrderDto(OrderHeaderEntity orderHeaderEntity)
        {
            var orderDto = new OrderDto
            {

                OrderHeaderId = orderHeaderEntity.Id,
                Status = orderHeaderEntity.Status.ToString(),
                DateCreated = orderHeaderEntity.DateCreated.ToString(),
                OrderLineItemsDto = new List<OrderLineItemDto>(),
            };

            foreach (var orderLineItemEntity in orderHeaderEntity.OrderLineItemEntities)
            {
                var orderLineItemDto = new OrderLineItemDto
                {
                    Id = orderLineItemEntity.Id,
                    ItemId = orderLineItemEntity.ItemId,
                    Quantity = orderLineItemEntity.Quantity,
                };
                orderDto.OrderLineItemsDto.Add(orderLineItemDto);
            }

            return orderDto;
        }

        private void CheckOrderStatusCanBeEdition(OrderHeaderEntity orderHeaderEntity)
        {
            if (orderHeaderEntity.Status == OrderStatus.Paid ||
               orderHeaderEntity.Status == OrderStatus.InDelivery ||
               orderHeaderEntity.Status == OrderStatus.InDelivery ||
               orderHeaderEntity.Status == OrderStatus.Completed)
            {
                throw new InvalidOperationException("Заказ не может быть отредактирован в текущем статусе заказа");
            }
        }

        private void CheckOrderStatusForDelete(OrderHeaderEntity orderHeaderEntity)
        {
            if (orderHeaderEntity.Status == OrderStatus.InDelivery ||
              orderHeaderEntity.Status == OrderStatus.Delivered ||
              orderHeaderEntity.Status == OrderStatus.Completed)
            {
                throw new InvalidOperationException("Действие недопустимо в текущем статусе заказа");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderService.DAL.Abstraction.Repositories;
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

        public async Task AddOrder(OrderEntity orderEntity)
        {
            await _dataContext.OrdersLineItems.AddAsync(orderEntity.OrderLineItemEntities.LastOrDefault());
            await _dataContext.OrderHeaders.AddAsync(orderEntity.Header);
            await _dataContext.Orders.AddAsync(orderEntity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<OrderEntity> GetOrder(Guid OrderId)
        {
            var orderEntity = await _dataContext.Orders
                .Include(o => o.Header)
                .Include(o => o.OrderLineItemEntities)
                .FirstOrDefaultAsync(o => o.Id == OrderId);

            if (orderEntity == null)
            {
                throw new ArgumentException("Заказ не найден");
            }

            return orderEntity;
        }

        public async Task AddItemLineForOrder(OrderLineItemEntity orderLineItem)
        {
            await _dataContext.OrdersLineItems.AddAsync(orderLineItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(OrderEntity order)
        {
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteItemForOrder(OrderLineItemEntity lineItem)
        {
             _dataContext.OrdersLineItems.Remove(lineItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<OrderLineItemEntity> FindItemForOrder(Guid lineItemId)
        {
            var lineItem = await _dataContext.OrdersLineItems.FirstOrDefaultAsync(o => o.Id == lineItemId);

            if (lineItem == null)
            {
                throw new ArgumentException("Товар не найден");
            }

           return lineItem;
        }

        public async Task<OrderEntity> FindOrderByItemId(OrderLineItemEntity lineItem)
        {
            var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == lineItem.OrderId);

            return order;
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

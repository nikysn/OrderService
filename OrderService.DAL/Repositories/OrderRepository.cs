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
            await _dataContext.OrderEntities.AddAsync(orderEntity);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<OrderEntity> GetOrder(Guid OrderId)
        {
            var orderEntity = await _dataContext.OrderEntities
                .Include(o => o.Header)
                .Include(o => o.OrderLineItemEntities)
                .FirstOrDefaultAsync(o => o.Id == OrderId);

            if (orderEntity == null)
            {
                throw new ArgumentException("Заказ не найден");
            }

            return orderEntity;
        }

        public async Task DeleteOrder(OrderEntity request)
        {
            _dataContext.OrderEntities.Remove(request);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

using OrderService.DAL.Entities;

namespace OrderService.DAL.Abstraction.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderEntity> GetOrder(Guid OrderId);
        Task AddOrder(OrderEntity orderEntity);
        Task DeleteOrder(OrderEntity orderEntity);
        Task SaveChanges();
    }
}

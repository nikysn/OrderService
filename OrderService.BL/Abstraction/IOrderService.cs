using OrderService.DAL.Common;
using OrderService.DAL.Contracts.Responses;
using OrderService.DAL.Entities;

namespace OrderService.BL.Abstraction
{
    public interface IOrderService
    {
        Task<OrderResponse> GetOrderId(Guid OrderId);
        Task<OrderResponse> CreateOrder(int quantityItem);
        Task<OrderResponse> UpdateOrder(Guid OrderId, OrderStatus newStatus);
        Task DeleteOrder(Guid OrderId);

    }
}

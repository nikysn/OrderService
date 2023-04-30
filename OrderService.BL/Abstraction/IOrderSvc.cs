using OrderService.DAL.Common;
using OrderService.DAL.Contracts.Requests;
using OrderService.DAL.Contracts.Responses;

namespace OrderService.BL.Abstraction
{
    public interface IOrderSvc
    {
        /// <summary>
        /// Получить заказ по id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task<OrderResponse> GetOrderId(Guid OrderId);
        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <param name="quantityItem"></param>
        /// <returns></returns>
        Task<OrderResponse> CreateOrder(int quantityItem);
        /// <summary>
        /// Изменить статус заказа
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OrderResponse> ChangeOrderStatus(ChangeOrderStatusRequest request);
        /// <summary>
        /// Добавить товар в заказ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OrderResponse> AddItemForOrder(AddItemForOrderRequest request);
        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task DeleteOrder(Guid OrderId);
        /// <summary>
        /// Удалить товар из заказа
        /// </summary>
        /// <param name="lineItemId"></param>
        /// <returns></returns>
        Task DeleteItemForOrder(Guid lineItemId);
    }
}

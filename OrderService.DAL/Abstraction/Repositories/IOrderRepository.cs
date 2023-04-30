using OrderService.DAL.Entities;

namespace OrderService.DAL.Abstraction.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получить заказ
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task<OrderEntity> GetOrder(Guid OrderId);
        /// <summary>
        /// Добавить заказ в БД
        /// </summary>
        /// <param name="orderEntity"></param>
        /// <returns></returns>
        Task AddOrder(OrderEntity orderEntity);
        /// <summary>
        /// Добавить товар в заказ
        /// </summary>
        /// <param name="orderLineItem"></param>
        /// <returns></returns>
        Task AddItemLineForOrder(OrderLineItemEntity orderLineItem);
        /// <summary>
        /// Найти товар в заказе
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderLineItemEntity> FindItemForOrder(Guid orderId);
        /// <summary>
        /// Найти заказ по Id товара
        /// </summary>
        /// <param name="lineItem"></param>
        /// <returns></returns>
        Task<OrderEntity> FindOrderByItemId(OrderLineItemEntity lineItem);
        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="orderEntity"></param>
        /// <returns></returns>
        Task DeleteOrder(OrderEntity orderEntity);
        /// <summary>
        /// Удалить товар из Заказа
        /// </summary>
        /// <param name="lineItem"></param>
        /// <returns></returns>
        Task DeleteItemForOrder(OrderLineItemEntity lineItem);
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();
    }
}

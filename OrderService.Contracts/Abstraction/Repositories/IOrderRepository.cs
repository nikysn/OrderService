using OrderService.Contracts.DTOModels;

namespace OrderService.Contracts.Abstraction.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получить заказ по Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task<OrderDto> GetOrderId(Guid OrderId);
        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <param name="quantityItem"></param>
        /// <returns></returns>
        Task<OrderDto> CreateOrder(int quantityItem);
        /// <summary>
        /// Изменить статус заказа
        /// </summary>
        /// <param name="changeOrderStatusDto"></param>
        /// <returns></returns>
        Task<OrderDto> ChangeOrderStatus(ChangeOrderStatusDto changeOrderStatusDto);
        /// <summary>
        /// Добавить товар в заказ
        /// </summary>
        /// <param name="addItemForOrderDto"></param>
        /// <returns></returns>
        Task<OrderDto> AddItemLineForOrder(AddItemForOrderDto addItemForOrderDto);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="orderHeaderId"></param>
       /// <returns></returns>
        Task DeleteOrder(Guid orderHeaderId);
        /// <summary>
        /// Удалить товар из Заказа
        /// </summary>
        /// <param name="lineItemId"></param>
        /// <returns></returns>
        Task DeleteItemForOrder(Guid lineItemId);
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();
    }
}

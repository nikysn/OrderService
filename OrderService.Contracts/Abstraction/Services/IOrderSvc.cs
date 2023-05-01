using OrderService.Contracts.DTOModels;

namespace OrderService.Contracts.Abstraction.Services
{
    public interface IOrderSvc
    {
        /// <summary>
        /// Получить заказ по id
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
        Task<OrderDto> AddItemForOrder(AddItemForOrderDto addItemForOrderDto);
        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="OrderHeaderId"></param>
        /// <returns></returns>
        Task DeleteOrder(Guid OrderHeaderId);
        /// <summary>
        /// Удалить товар из заказа
        /// </summary>
        /// <param name="lineItemId"></param>
        /// <returns></returns>
        Task DeleteItemForOrder(Guid lineItemId);
    }
}

using OrderService.DAL.Common;

namespace OrderService.DAL.Contracts.Requests
{
    public class ChangeOrderStatusRequest
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}

using OrderService.DAL.Common;

namespace OrderService.PL.Requests
{
    public class ChangeOrderStatusRequest
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}

using OrderService.DAL.Common;

namespace OrderService.PL.Requests
{
    public class ChangeOrderRequest
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
        public int QuantityItem { get; set; }
    }
}

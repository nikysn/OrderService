using OrderService.Contracts.Common;

namespace OrderService.API.Model.Requests
{
    public class ChangeOrderRequest
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
        public int QuantityItem { get; set; }
    }
}

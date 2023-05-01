using OrderService.Contracts.Common;

namespace OrderService.API.Model.Requests
{
    public class ChangeOrderStatusRequest
    {
        public Guid OrderHeaderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}

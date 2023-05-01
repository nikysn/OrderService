using OrderService.Contracts.Common;

namespace OrderService.Contracts.DTOModels
{
    public class ChangeOrderStatusDto
    {
        public Guid OrderHeaderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}

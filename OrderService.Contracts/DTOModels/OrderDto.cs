using OrderService.Contracts.Common;

namespace OrderService.Contracts.DTOModels
{
    public class OrderDto
    {
        public Guid OrderHeaderId { get; set; }
        public string Status { get; set; }
        public string DateCreated { get; set; }
        public List<OrderLineItemDto> OrderLineItemsDto { get; set; }
       
    }
}

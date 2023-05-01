using OrderService.Contracts.Common;

namespace OrderService.Contracts.DTOModels
{
    public class OrderHeaderDto
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

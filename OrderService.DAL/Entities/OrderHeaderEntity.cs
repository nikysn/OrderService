using OrderService.DAL.Common;

namespace OrderService.DAL.Entities
{
    public class OrderHeaderEntity
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderLineItemEntity> OrderLineItemEntities { get; set; }
    }
}

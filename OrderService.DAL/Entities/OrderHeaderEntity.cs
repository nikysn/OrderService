using OrderService.DAL.Common;

namespace OrderService.DAL.Entities
{
    public class OrderHeaderEntity
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public OrderHeaderEntity()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.New;
            DateCreated = DateTime.UtcNow;
        }
        public OrderHeaderEntity(Guid orderId) : this()
        {
            OrderId = orderId;
        }
    }
}

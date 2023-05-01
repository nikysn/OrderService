using OrderService.Contracts.Common;

namespace OrderService.DAL.Entities
{
    public class OrderHeaderEntity
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderLineItemEntity> OrderLineItemEntities { get; set; }

        public OrderHeaderEntity()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.New;
            DateCreated = DateTime.UtcNow;
            OrderLineItemEntities = new List<OrderLineItemEntity>();
        }
        public OrderHeaderEntity(int quantityItem) : this()
        {
            var orderLineItemEntity = new OrderLineItemEntity(Id, quantityItem);
            OrderLineItemEntities.Add(orderLineItemEntity);
        }
    }
}

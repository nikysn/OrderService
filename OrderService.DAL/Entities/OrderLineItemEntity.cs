namespace OrderService.DAL.Entities
{
    public class OrderLineItemEntity
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderHeaderId { get; set; }
        public OrderHeaderEntity OrderHeader { get; set; }
        public OrderLineItemEntity()
        {
            Id = Guid.NewGuid();
            ItemId = Guid.NewGuid();
        }
        public OrderLineItemEntity(Guid orderHeaderId, int quantityItem) : this()
        {
            Quantity = quantityItem;
            OrderHeaderId = orderHeaderId;
        }
    }
}

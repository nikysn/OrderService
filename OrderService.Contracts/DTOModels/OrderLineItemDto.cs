namespace OrderService.Contracts.DTOModels
{
    public class OrderLineItemDto
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
       
    }
}

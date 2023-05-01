namespace OrderService.Contracts.DTOModels
{
    public class AddItemForOrderDto
    {
        public Guid OrderHeaderId { get; set; }
        public int QuantityItem { get; set; }
    }
}

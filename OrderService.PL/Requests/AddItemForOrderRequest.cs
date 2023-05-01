namespace OrderService.PL.Requests
{
    public class AddItemForOrderRequest
    {
        public Guid OrderId { get; set; }
        public int QuantityItem { get; set; }
    }
}

namespace OrderService.API.Model.Requests
{
    public class AddItemForOrderRequest
    {
        public Guid OrderHeaderId { get; set; }
        public int QuantityItem { get; set; }
    }
}

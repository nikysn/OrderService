namespace OrderService.PL.Responses
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public List<LineItemResponse> Lines { get; set; }
    }
}

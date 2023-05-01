namespace OrderService.API.Model.Responces
{
    public class OrderResponse
    {
        public Guid OrderHeaderId { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public List<LineItemResponse> Lines { get; set; }
    }
}

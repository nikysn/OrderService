namespace OrderService.API.Model.Responces
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Created { get; set; }
        public List<LineItemResponse> Lines { get; set; }
    }
}

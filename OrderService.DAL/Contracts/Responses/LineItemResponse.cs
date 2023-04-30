namespace OrderService.DAL.Contracts.Responses
{
    public class LineItemResponse
    {
        public Guid ItemId { get; set; }
        public int Qty { get; set; }
    }
}

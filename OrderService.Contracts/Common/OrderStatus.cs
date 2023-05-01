namespace OrderService.Contracts.Common
{
    public enum OrderStatus
    {
        New,
        WaitingForPayment,
        Paid,
        InDelivery,
        Delivered,
        Completed
    }
}

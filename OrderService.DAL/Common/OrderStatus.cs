
namespace OrderService.DAL.Common
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

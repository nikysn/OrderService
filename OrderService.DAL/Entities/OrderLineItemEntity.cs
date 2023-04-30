using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DAL.Entities
{
    public class OrderLineItemEntity
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public OrderLineItemEntity()
        {
            Id = Guid.NewGuid();
            ItemId = Guid.NewGuid();
        }
        public OrderLineItemEntity(int quantityItem,Guid orderId) : this()
        {
            Quantity = quantityItem;
            OrderId = orderId;
        }
    }
}

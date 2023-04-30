using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DAL.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public OrderHeaderEntity Header { get; set; }
        public List<OrderLineItemEntity> OrderLineItemEntities { get; set; }
        public OrderEntity() 
        {
            Id = Guid.NewGuid();
            Header = new OrderHeaderEntity(Id);
            OrderLineItemEntities = new List<OrderLineItemEntity>();
        }
        public OrderEntity(int quantityItem) : this()
        {
            var orderLineItemEntity = new OrderLineItemEntity(Id, quantityItem);
            OrderLineItemEntities.Add(orderLineItemEntity);
        }
    }
}

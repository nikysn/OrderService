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
        [Range(0, int.MaxValue, ErrorMessage = "Количество должно быть целым, не отрицательным числом")]
        public int Quantity { get; set; }
        public Guid OrderHeaderId { get; set; }
        public OrderHeaderEntity OrderHeader { get; set; }
    }
}

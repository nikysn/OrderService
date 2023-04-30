using OrderService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DAL.Contracts.Responses
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public List<LineItemResponse> Lines { get; set; }
    }
}

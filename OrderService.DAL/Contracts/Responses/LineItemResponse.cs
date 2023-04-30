using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DAL.Contracts.Responses
{
    public class LineItemResponse
    {
        public Guid ItemId { get; set; }
        public int Qty { get; set; }
    }
}

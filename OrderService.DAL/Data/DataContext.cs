using Microsoft.EntityFrameworkCore;
using OrderService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderHeaderEntity> OrderHeaders { get; set; }
        public DbSet<OrderLineItemEntity> OrdersLineItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderService.DAL.Entities;

namespace OrderService.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       
        public DbSet<OrderHeaderEntity> OrderHeaders { get; set; }
        public DbSet<OrderLineItemEntity> OrdersLineItems { get; set; }
    }
}

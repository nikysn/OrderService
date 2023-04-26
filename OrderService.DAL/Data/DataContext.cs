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

       /* protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("Server=localhost;Port=5432;Database=OrderService; User Id=postgres;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/

        public DbSet<OrderHeaderEntity> OrderHeaders { get; set; }
        public DbSet<OrderLineItemEntity> OrdersLineItems { get; set; }
    }
}

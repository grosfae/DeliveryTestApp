using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.Components
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        { 
        }
        public DbSet<DeliveryLog> DeliveryLog {  get; set; }
        public DbSet<Area> Area {  get; set; }
        public DbSet<Order> Order {  get; set; }
        public DbSet<SelectionResult> SelectionResult {  get; set; }
        public DbSet<SelectionResultOrder> SelectionResultOrder {  get; set; }
    }
}

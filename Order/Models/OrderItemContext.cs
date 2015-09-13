using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Orders.Models
{    
    public class OrderItemContext : DbContext
    {
        public OrderItemContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
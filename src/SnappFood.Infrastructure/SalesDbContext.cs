using Microsoft.EntityFrameworkCore;
using SnappFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Infrastructure
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SalesDbContext()
        {
        }
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

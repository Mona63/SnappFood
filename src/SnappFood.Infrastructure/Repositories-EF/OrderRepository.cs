using Microsoft.EntityFrameworkCore;
using SnappFood.Core;
using SnappFood.Core.Entities;

namespace SnappFood.Infrastructure
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SalesDbContext dbContext) : base(dbContext)
        {
        }
    }
    
}

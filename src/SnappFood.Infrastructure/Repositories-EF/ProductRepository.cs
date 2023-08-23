using SnappFood.Core;
using SnappFood.Core.Entities;

namespace SnappFood.Infrastructure
{
    public class ProductRepository:  GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SalesDbContext dbContext) : base(dbContext)
        {
        }
    }
}

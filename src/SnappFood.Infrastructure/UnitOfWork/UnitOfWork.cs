using Microsoft.EntityFrameworkCore;
using SnappFood.Core;

namespace SnappFood.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesDbContext _dbContext;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext); }
        }
        public IOrderRepository OrderRepository
        {
            get { return _orderRepository = _orderRepository ?? new OrderRepository(_dbContext); }
        }


        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
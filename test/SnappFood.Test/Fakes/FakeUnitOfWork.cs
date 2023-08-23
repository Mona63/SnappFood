using SnappFood.Core;

namespace SnappFood.Test
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new FakeProductRepository(); }
        }
        public IOrderRepository OrderRepository
        {
            get { return _orderRepository = _orderRepository ?? new FakeOrderRepository(); }
        }
        public void Commit()
        {

        }

        public Task CommitAsync()
        {
            return Task.CompletedTask;
        }

        public void Rollback()
        {

        }

        public Task RollbackAsync()
        {
            return Task.CompletedTask;
        }
    }
}

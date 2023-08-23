using SnappFood.Core;
using SnappFood.Core.Entities;
using System.Linq.Expressions;

namespace SnappFood.Test
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}

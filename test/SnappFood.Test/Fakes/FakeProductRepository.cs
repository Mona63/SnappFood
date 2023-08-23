using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SnappFood.Core;
using SnappFood.Core.Entities;
using System.Linq.Expressions;

namespace SnappFood.Test
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly IList<Product> _db = new List<Product>();
        private int lastId = 0;

        public void Add(Product entity)
        {
            entity.Id = ++lastId;
            _db.Add(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db;
        }

        public Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression)
        {
            return Task.FromResult<IEnumerable<Product>>(_db.AsQueryable().Where(expression).ToList());
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_db);
        }

        public Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        {
            try
            {
                var entity = _db.AsQueryable().FirstOrDefault(expression);
                return Task.FromResult(entity);

            }
            catch (Exception)
            {

                return Task.FromResult<Product>(null);
            }
        }

        public Product GetById(int id)
        {
            return _db.AsQueryable().FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            var entityToUpdate = _db.FirstOrDefault(p => p.Id == entity.Id);
            if (entityToUpdate != null) entityToUpdate = entity;

        }
    }
}

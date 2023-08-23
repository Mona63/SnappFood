using Microsoft.EntityFrameworkCore;
using SnappFood.Core;
using System.Linq.Expressions;

namespace SnappFood.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {
        protected readonly SalesDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;


        public GenericRepository(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }


        public void Add(T entity)
            => _dbContext.Add(entity);
        public void Update(T entity)
           => _dbContext.Update(entity);
        public T GetById(int id)
           => _entitiySet.FirstOrDefault<T>(c=>c.Id==id);
        public IEnumerable<T> GetAll()
           => _entitiySet.ToList();
        public async Task<IEnumerable<T>> GetAllAsync()
            => await _entitiySet.ToListAsync();
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
            => await _entitiySet.Where(expression).ToListAsync();
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => await _entitiySet.FirstOrDefaultAsync(expression);


       

    }
}

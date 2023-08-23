using Microsoft.Extensions.Caching.Memory;
using SnappFood.Core;
using SnappFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Infrastructure
{
    public class CachedProductRepository : IReadOnlyRepository<Product>
    {
        private readonly ProductRepository _repository;
        private readonly IMemoryCache _cache;
        private const string ProcutsCacheKey = "Product";
        private MemoryCacheEntryOptions cacheOptions;


        public CachedProductRepository(ProductRepository repository,IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(20));
        }

        public Product GetById(int id)
        {
            string key = ProcutsCacheKey + "-" + id;

            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return _repository.GetById(id);
                //var productToCahe= _repository.GetById(id);
                //if (productToCahe != null) { return productToCahe; }
                //return null;
            });
        }

        public IEnumerable<Product> GetAll()
        {
            return _cache.GetOrCreate(ProcutsCacheKey, entry =>
            {
                entry.SetOptions(cacheOptions);
                return  _repository.GetAll();
            });
        }
       
    }
}

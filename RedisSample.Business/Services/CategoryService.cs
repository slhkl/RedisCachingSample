using RedisSample.DataAccess.Services;
using RedisSampleData.Model;

namespace RedisSample.Business.Services
{
    public class CategoryService : ICategoryService
    {
        static List<Category> Categories => new()
        {
            new Category { Id = 1, Name = "Electronic" },
            new Category { Id = 2, Name = "Clothes" }
        };

        private readonly ICacheService _cache;
        public CategoryService(ICacheService cache)
        {
            _cache = cache;
        }

        public List<Category> GetAll()
        {
            return _cache.GetOrAdd("allCategories", () => { return Categories; });
        }
    }
}

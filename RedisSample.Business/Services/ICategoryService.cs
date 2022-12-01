using RedisSampleData.Model;

namespace RedisSample.Business.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}

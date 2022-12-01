using RedisSample.DataAccess.Services;
using StackExchange.Redis;

namespace RedisSample.StartupConfiguration
{
    public static class RedisConfigurationExtension
    {
        public static void AddRedisConnection(this IServiceCollection services, IConfiguration configuration)
        {
            string uri = configuration.GetConnectionString("Redis");
            var multiplexer = ConnectionMultiplexer.Connect(uri);
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);
            services.AddSingleton<ICacheService, RedisCacheService>();
        }
    }
}

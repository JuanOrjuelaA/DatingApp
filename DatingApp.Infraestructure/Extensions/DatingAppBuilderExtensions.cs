namespace DatingApp.Infrastructure.Extensions
{
    using System.Reflection.Metadata;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DatingAppBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection InitializeDatingAppDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<DatingDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
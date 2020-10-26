namespace DatingApp.Services.Extensions
{
    using Jwt;
    using Microsoft.Extensions.DependencyInjection;
    using Users;

    public static class DatingAppServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatingServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
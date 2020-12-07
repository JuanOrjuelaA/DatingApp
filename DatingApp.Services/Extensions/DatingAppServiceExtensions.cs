namespace DatingApp.Services.Extensions
{
    using AutoMapper;
    using Infrastructure.Repositories.Users;
    using Jwt;
    using Mappings;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new ServiceMappingProfile()); });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
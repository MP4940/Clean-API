using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddSingleton<MockDatabase>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer("Server=SMARTFRIDGE; Database=AnimalModels; Trusted_Connection=true; TrustServerCertificate=true;");
            });
            return services;
        }
    }
}
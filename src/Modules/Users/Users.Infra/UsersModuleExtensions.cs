using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Services;
using Users.Application.Services.Interfaces;
using Users.Domain.Interfaces;
using Users.Infra.Data;
using Users.Infra.Repositories;

namespace Users.Infra
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o DbContext do módulo de usuários
            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // Registra serviços e repositórios
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

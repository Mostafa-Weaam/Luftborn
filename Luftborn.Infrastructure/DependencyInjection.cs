using Luftborn.Application.Interfaces;
using Luftborn.Application.Services;
using Luftborn.Domain.IRepository;
using Luftborn.Infrastructure.Dbcontext;
using Luftborn.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luftborn.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<LuftbornDbContext>(options =>
                options.UseMySql(connectionString, 
                    ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly("Luftborn.Infrastructure")));

            // Register repositories
            services.AddScoped<IItemRepository, ItemRepository>();
            
            // Register services
            services.AddScoped<IItemService, ItemService>();

            return services;
        }
    }
}
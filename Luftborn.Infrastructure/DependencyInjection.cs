using Luftborn.Infrastructure.Dbcontext;
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

            return services;
        }
    }
}
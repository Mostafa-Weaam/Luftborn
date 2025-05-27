using Luftborn.Domain;
using Microsoft.EntityFrameworkCore;

namespace Luftborn.Infrastructure.Dbcontext
{
    public class LuftbornDbContext : DbContext
    {
        public LuftbornDbContext(DbContextOptions<LuftbornDbContext> options) : base(options) { }
        public DbSet<Item> Items => Set<Item>();
    }
}

using Luftborn.Domain;
using Luftborn.Domain.IRepository;
using Luftborn.Infrastructure.Dbcontext;
using Microsoft.EntityFrameworkCore;

namespace Luftborn.Infrastructure.Repositories
{
    internal class ItemRepository : IITemRepository
    {
        private readonly LuftbornDbContext _context;
        public ItemRepository(LuftbornDbContext context) => _context = context;

        public async Task<IEnumerable<Item>> GetAllAsync() => await _context.Items.ToListAsync();
        public async Task<Item?> GetByIdAsync(Guid id) => await _context.Items.FindAsync(id);
        public async Task AddAsync(Item item) { _context.Items.Add(item); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Item item) { _context.Items.Update(item); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Guid id)
        {
            var item = await GetByIdAsync(id);
            if (item != null) { _context.Items.Remove(item); await _context.SaveChangesAsync(); }
        }
    }
}

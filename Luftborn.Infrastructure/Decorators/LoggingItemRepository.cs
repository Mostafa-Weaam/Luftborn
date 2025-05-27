using Luftborn.Domain;
using Luftborn.Domain.IRepository;
using Microsoft.Extensions.Logging;

namespace Luftborn.Infrastructure.Decorators
{
    public class LoggingItemRepository : IITemRepository
    {
        private readonly IITemRepository _inner;
        private readonly ILogger<LoggingItemRepository> _logger;

        public LoggingItemRepository(IITemRepository inner, ILogger<LoggingItemRepository> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all items");
            return await _inner.GetAllAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching item with ID {Id}", id);
            return await _inner.GetByIdAsync(id);
        }

        public async Task AddAsync(Item item)
        {
            _logger.LogInformation("Adding new item");
            await _inner.AddAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            _logger.LogInformation("Updating item with ID {Id}", item.Id);
            await _inner.UpdateAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Deleting item with ID {Id}", id);
            await _inner.DeleteAsync(id);
        }
    }
}

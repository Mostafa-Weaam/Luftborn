using Luftborn.Application.IStartegies;
using Luftborn.Domain;
using Luftborn.Domain.IRepository;

namespace Luftborn.Infrastructure.Strategies
{
    public class ItemSaveStrategy : ISaveStrategy
    {
        private readonly IITemRepository _repository;
        public ItemSaveStrategy(IITemRepository repository) => _repository = repository;

        public async Task SaveAsync(Item item) => await _repository.AddAsync(item);
    }
}

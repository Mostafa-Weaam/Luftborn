using Luftborn.Domain;

namespace Luftborn.Application.IStartegies
{
    public interface ISaveStrategy
    {
        Task SaveAsync(Item item);
    }
}

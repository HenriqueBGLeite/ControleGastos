using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task Add(Transactions transaction, CancellationToken ct = default);
        Task Delete(Transactions transaction, CancellationToken ct = default);
        Task<IList<Transactions>> GetAll(Guid userId, CancellationToken ct = default);
        Task<IList<Transactions>> GetByCategory(Guid categoryId, CancellationToken ct = default);
        Task<Transactions?> GetById(Guid id, CancellationToken ct = default);
        Task Update(Transactions transaction, CancellationToken ct = default);
    }
}
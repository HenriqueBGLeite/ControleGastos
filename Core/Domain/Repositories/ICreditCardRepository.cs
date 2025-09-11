using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Domain.Repositories
{
    public interface ICreditCardRepository
    {
        Task Add(CreditCards card, CancellationToken ct = default);
        Task Delete(CreditCards card, CancellationToken ct = default);
        Task<IList<CreditCards>> GetAll(Guid userId, CancellationToken ct = default);
        Task<CreditCards?> GetById(Guid id, CancellationToken ct = default);
        Task Update(CreditCards card, CancellationToken ct = default);
    }
}
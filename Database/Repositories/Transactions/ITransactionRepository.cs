using Models;

namespace Database.Repositories.Transactions
{
    public interface ITransactionRepository
    {
        Task Add(TransactionModel transaction, CancellationToken ct = default);
        Task Delete(TransactionModel transaction, CancellationToken ct = default);
        Task<IList<TransactionModel>> GetAll(Guid userId, CancellationToken ct = default);
        Task<IList<TransactionModel>> GetByCategory(Guid categoryId, CancellationToken ct = default);
        Task<TransactionModel?> GetById(Guid id, CancellationToken ct = default);
        Task Update(TransactionModel transaction, CancellationToken ct = default);
    }
}
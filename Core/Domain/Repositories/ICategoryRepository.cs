using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Enums;

namespace ControleGastos.Core.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task Add(Categories category, CancellationToken ct = default);
        Task Delete(Categories category, CancellationToken ct = default);
        Task Update(Categories category, CancellationToken ct = default);
        Task<IList<Categories>> GetAll(Guid userId, CancellationToken ct = default);
        Task<Categories?> GetById(Guid id, CancellationToken ct = default);
        Task<Categories?> GetByNameAndType(string name, OperationType? type, CancellationToken ct = default);
    }
}
using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Application.UseCases.RegisterCategories
{
    public interface IRegisterCategoryUseCase
    {
        Task OnDeletedInDatabase(Categories category, CancellationToken ct = default);
        Task OnEditCategoryInDatabase(Categories category, CancellationToken ct = default);
        Task<IList<Categories>> OnGetAll(Guid userId, CancellationToken ct = default);
        Task OnRegisterCategoryInDatabase(Categories category, CancellationToken ct = default);
    }
}
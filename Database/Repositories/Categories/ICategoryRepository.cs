using Models;

namespace Database.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task Add(CategoryModel category, CancellationToken ct = default);
        Task Delete(CategoryModel category, CancellationToken ct = default);
        Task Update(CategoryModel category, CancellationToken ct = default);
        Task<IList<CategoryModel>> GetAll(Guid userId, CancellationToken ct = default);
        Task<CategoryModel?> GetById(Guid id, CancellationToken ct = default);
    }
}
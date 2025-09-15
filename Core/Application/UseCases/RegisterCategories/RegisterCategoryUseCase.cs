using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Application.UseCases.RegisterCategories
{
    public class RegisterCategoryUseCase : IRegisterCategoryUseCase
    {
        private ICategoryRepository _categoryRepository;
        private ITransactionRepository _transactionRepository;

        public RegisterCategoryUseCase(ICategoryRepository categoryRepository, 
            ITransactionRepository transactionRepository)
        {
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<IList<Categories>> OnGetAll(Guid userId, CancellationToken ct = default)
        {
            return await _categoryRepository.GetAll(userId, ct);
        }

        public async Task OnDeletedInDatabase(Categories category, CancellationToken ct = default)
        {
            var categoryExists = await OnExistsCategoryInDatabase(category, ct);

            if (!categoryExists)
                throw new Exception($"Não existe uma categoria com esse nome: {category.Name}. Atualize e tente novamente.");

            var transactionsLinked = await OnCategoryLinkedOnTransaction(category, ct);

            if (transactionsLinked)
                throw new Exception($"A categoria {category.Name} esta vinculada à transações. Não é possível exlcuir categoria com vinculo.");

            await _categoryRepository.Delete(category,ct);
        }

        public async Task OnRegisterCategoryInDatabase(Categories category, CancellationToken ct = default)
        {
            var categoryExists = await OnExistsCategoryInDatabase(category, ct);

            if (categoryExists)
                throw new Exception($"Já existe uma outra categoria para o nome: {category.Name} do tipo selecionado.");

            //TODO - Implementar melhorias na criação da categoria
            category.Id = Guid.NewGuid();
            category.CreatedAt = DateTimeOffset.Now;
            category.UpdatedAt = DateTimeOffset.Now;

            await _categoryRepository.Add(category, ct);
        }

        private async Task<bool> OnExistsCategoryInDatabase(Categories category, CancellationToken ct = default)
        {
            var normalizeName = category.Name ?? string.Empty;

            var categoryExists = await _categoryRepository.GetByNameAndType(normalizeName, category.OperationType, ct);

            return categoryExists != null;
        }

        private async Task<bool> OnCategoryLinkedOnTransaction(Categories category, CancellationToken ct = default)
        {
            var transactionsLinked = await _transactionRepository.GetByCategory(category.Id,ct);

            return transactionsLinked.Count > 0;
        }
    }
}

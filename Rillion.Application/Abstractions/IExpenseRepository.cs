
namespace Rillion.Application.Abstractions;

public interface IExpenseRepository
{
    public Task<Domain.Entities.Expense> AddAsync(Domain.Entities.Expense expense, CancellationToken cancellationToken);
    public Task<Domain.Entities.Expense?> DeleteAsync(long id, long userId, CancellationToken cancellationToken);
    public Task<IEnumerable<Domain.Entities.Expense>> GetPageAsync(long userId, int page, int pageSize, CancellationToken cancellationToken);
    public Task<Domain.Entities.Expense?> UpdateAmountAsync(long id, long userId, long amount, CancellationToken cancellationToken);
    public Task<Domain.Entities.Expense?> UpdateCategoryIdAsync(long id, long userId, long categoryId, CancellationToken cancellationToken);
}
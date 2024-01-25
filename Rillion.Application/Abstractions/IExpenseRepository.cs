namespace Rillion.Application.Abstractions;

public interface IExpenseRepository
{
    public Task<IEnumerable<Domain.Entities.Expense>> GetPageAsync(long userId, int page, int pageSize, CancellationToken cancellationToken);
    public Task<Domain.Entities.Expense> AddAsync(Domain.Entities.Expense expense, CancellationToken cancellationToken);
    public Task<Domain.Entities.Expense> UpdateAsync(long id, long amount, CancellationToken cancellationToken);
}
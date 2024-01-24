namespace Rillion.Application.Abstractions;

public interface IExpenseRepository
{
    public Task<IEnumerable<Expense>> GetPageAsync(long userId, int page, int pageSize, CancellationToken cancellationToken);
    public Task<IEnumerable<Expense>> GetPageAsync<TKey>(long userId, int page, int pageSize, System.Linq.Expressions.Expression<Func<Expense, TKey>> orderBy, CancellationToken cancellationToken);
    public Task<Expense> AddAsync(Expense expense, CancellationToken cancellationToken);
    public Task<Expense> UpdateAsync(long id, long amount, CancellationToken cancellationToken);
}
using Microsoft.EntityFrameworkCore;
using Rillion.Application.Abstractions;

namespace Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly ApplicationDbContext _context;

    public ExpenseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Expense> AddAsync(Expense expense, CancellationToken cancellationToken)
    {
        _context.Add(expense);

        await _context.SaveChangesAsync(cancellationToken);

        return expense;
    }

    public async Task<IEnumerable<Expense>> GetPageAsync<TKey>(long userId, int page, int pageSize, System.Linq.Expressions.Expression<Func<Expense, TKey>> orderyBy, CancellationToken cancellationToken) =>
        await _context.Expenses
            .AsNoTracking()
            .Where(n => n.UserId == userId)
            .OrderBy(orderyBy)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public Task<IEnumerable<Expense>> GetPageAsync(long userId, int page, int pageSize, CancellationToken cancellationToken) =>
        GetPageAsync(userId, page, pageSize, n => n.Date, cancellationToken);

    public async Task<Expense> UpdateAsync(long id, long amount, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses.SingleAsync(n => n.Id == id);

        expense.Amount = amount;

        await _context.SaveChangesAsync();

        return expense;
    }
}
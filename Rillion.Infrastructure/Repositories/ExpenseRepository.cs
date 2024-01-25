using Microsoft.EntityFrameworkCore;
using Rillion.Application.Abstractions;
using Rillion.Domain.Entities;
using Rillion.Infrastructure;

namespace Rillian.Infrastructure.Repositories;

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

    public async Task<Expense?> DeleteAsync(long id, long userId, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses.SingleOrDefaultAsync(n => n.Id == id && n.UserId == userId, cancellationToken);

        if (expense is null || cancellationToken.IsCancellationRequested)
            return null;

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync(cancellationToken);

        return expense;
    }

    public async Task<IEnumerable<Expense>> GetPageAsync(long userId, int page, int pageSize, CancellationToken cancellationToken) =>
        await _context.Expenses
            .AsNoTracking()
            .Where(n => n.UserId == userId)
            .OrderBy(n => n.Id)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

    public async Task<Expense?> UpdateAmountAsync(long id, long userId, long amount, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses.SingleOrDefaultAsync(n => n.Id == id && n.UserId == userId, cancellationToken);

        if (expense is null || cancellationToken.IsCancellationRequested)
            return null;

        expense.Amount = amount;

        await _context.SaveChangesAsync(cancellationToken);

        return expense;
    }

    public async Task<Expense?> UpdateCategoryIdAsync(long id, long userId, long categoryId, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses.SingleOrDefaultAsync(n => n.Id == id && n.UserId == userId, cancellationToken);

        if (expense is null || cancellationToken.IsCancellationRequested)
            return null;

        expense.CategoryId = categoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return expense;
    }
}
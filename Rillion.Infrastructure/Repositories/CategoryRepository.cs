using Microsoft.EntityFrameworkCore;
using Rillion.Application.Abstractions;
using Rillion.Domain.Entities;

namespace Rillion.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> AddAsync(string name, CancellationToken cancellationToken)
    {
        var category = new Category { Name = name };

        _context.Add(category);
        await _context.SaveChangesAsync(cancellationToken);

        return category;
    }

    public async Task<Category?> DeleteAsync(long id, CancellationToken cancellationToken)
    {

        var category = await _context.Categories.SingleOrDefaultAsync(n => n.Id == id, cancellationToken);

        if (category is null || cancellationToken.IsCancellationRequested)
            return null;

        _context.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);

        return category;
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken) =>
        await _context.Categories.ToListAsync(cancellationToken);

    public async Task<Category?> UpdateAsync(long id, string name, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.SingleOrDefaultAsync(n => n.Id == id, cancellationToken);

        if (category is null || cancellationToken.IsCancellationRequested)
            return null;

        category.Name = name;

        await _context.SaveChangesAsync(cancellationToken);

        return category;
    }
}
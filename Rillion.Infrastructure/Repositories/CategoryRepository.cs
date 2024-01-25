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

    public async Task<Category> AddAsync(string name)
    {
        var category = new Category { Name = name };

        _context.Add(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> DeleteAsync(long id)
    {

        var category = await _context.Categories.SingleOrDefaultAsync(n => n.Id == id);

        if (category is null)
            return null;

        _context.Remove(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _context.Categories.ToListAsync();

    public async Task<Category?> UpdateAsync(long id, string name)
    {
        var category = await _context.Categories.SingleOrDefaultAsync(n => n.Id == id);

        if (category is null)
            return null;

        category.Name = name;

        await _context.SaveChangesAsync();

        return category;
    }
}
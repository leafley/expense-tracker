
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

    public async Task<Category> UpdateAsync(long id, string name)
    {
        var category = _context.Categories.SingleOrDefault(n => n.Id == id);

        if (category is null)
            throw new InvalidOperationException("Update: Category does not exist");

        category.Name = name;

        await _context.SaveChangesAsync();

        return category;
    }
}
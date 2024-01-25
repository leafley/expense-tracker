
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
}
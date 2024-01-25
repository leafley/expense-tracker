public interface ICategoryRepository
{
    public Task<Category> AddAsync(string name);
    public Task<Category?> DeleteAsync(long id);
    public Task<IEnumerable<Category>> GetAllAsync();
    public Task<Category?> UpdateAsync(long id, string name);
}
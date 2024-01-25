public interface ICategoryRepository
{
    public Task<Category> AddAsync(string name);
    public Task<Category> UpdateAsync(long id, string name);
}
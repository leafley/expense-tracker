public interface ICategoryRepository
{
    public Task<Category> AddAsync(string name);
}
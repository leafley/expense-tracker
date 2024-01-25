namespace Rillion.Application.Abstractions;

public interface ICategoryRepository
{
    public Task<Domain.Entities.Category> AddAsync(string name);
    public Task<Domain.Entities.Category?> DeleteAsync(long id);
    public Task<IEnumerable<Domain.Entities.Category>> GetAllAsync();
    public Task<Domain.Entities.Category?> UpdateAsync(long id, string name);
}
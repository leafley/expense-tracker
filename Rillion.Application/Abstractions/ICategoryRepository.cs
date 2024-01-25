namespace Rillion.Application.Abstractions;

public interface ICategoryRepository
{
    public Task<Domain.Entities.Category> AddAsync(string name, CancellationToken cancellationToken);
    public Task<Domain.Entities.Category?> DeleteAsync(long id, CancellationToken cancellationToken);
    public Task<IEnumerable<Domain.Entities.Category>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Domain.Entities.Category?> UpdateAsync(long id, string name, CancellationToken cancellationToken);
}
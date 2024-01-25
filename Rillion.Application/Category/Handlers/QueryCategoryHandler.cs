using MediatR;

public class QueryCategoryHandler : IRequestHandler<QueryCategory, IEnumerable<Category>>
{
    private readonly ICategoryRepository _repository;

    public QueryCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> Handle(QueryCategory request, CancellationToken cancellationToken) =>
        await _repository.GetAllAsync();
}
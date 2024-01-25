using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Category.Queries;

namespace Rillion.Application.Category.Handlers;

public class QueryCategoryHandler : IRequestHandler<QueryCategory, IEnumerable<Domain.Entities.Category>>
{
    private readonly ICategoryRepository _repository;

    public QueryCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Domain.Entities.Category>> Handle(QueryCategory request, CancellationToken cancellationToken) =>
        await _repository.GetAllAsync(cancellationToken);
}
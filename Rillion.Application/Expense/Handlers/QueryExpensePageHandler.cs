using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Queries;

namespace Rillion.Application.Expense.Handlers;

public class QueryExpensePageHandler : IRequestHandler<QueryExpensePage, IEnumerable<Domain.Entities.Expense>>
{
    private readonly IExpenseRepository _repository;

    public QueryExpensePageHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Domain.Entities.Expense>> Handle(QueryExpensePage request, CancellationToken cancellationToken) =>
        await _repository.GetPageAsync(request.UserId, request.Page, request.PageSize, cancellationToken);
}
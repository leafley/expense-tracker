using MediatR;

namespace Rillion.Application.Expense.Queries;

public record QueryExpensePage(long UserId, int Page, int PageSize) : IRequest<IEnumerable<Domain.Entities.Expense>>;
using MediatR;

namespace Rillion.Application.Expense.Queries;

public record QueryExpensePage(long UserId, int Page, int? PageSize = 20) : IRequest<IEnumerable<Domain.Entities.Expense>>;
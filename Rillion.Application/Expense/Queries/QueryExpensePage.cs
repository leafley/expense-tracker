using MediatR;

public record QueryExpensePage(long UserId, int Page, int PageSize) : IRequest<IEnumerable<Expense>>;
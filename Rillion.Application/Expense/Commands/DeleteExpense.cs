using MediatR;

public record DeleteExpense(long Id, long UserId) : IRequest<Expense>;
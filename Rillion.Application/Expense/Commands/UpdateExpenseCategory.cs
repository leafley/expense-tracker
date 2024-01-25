using MediatR;

public record UpdateExpenseCategory(long Id, long UserId, long CategoryId) : IRequest<Expense>;
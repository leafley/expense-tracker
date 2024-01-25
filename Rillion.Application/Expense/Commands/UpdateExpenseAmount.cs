using MediatR;

public record UpdateExpenseAmount(long Id, long UserId, long Amount) : IRequest<Expense>;
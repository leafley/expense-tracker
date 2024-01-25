using MediatR;

namespace Rillion.Application.Expense.Commands;

public record UpdateExpenseAmount(long Id, long UserId, long Amount) : IRequest<Domain.Entities.Expense>;
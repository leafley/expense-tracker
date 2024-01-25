using MediatR;

namespace Rillion.Application.Expense.Commands;

public record DeleteExpense(long Id, long UserId) : IRequest<Domain.Entities.Expense>;
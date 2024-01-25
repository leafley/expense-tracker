using MediatR;

namespace Rillion.Application.Expense.Commands;

public record UpdateExpenseCategory(long Id, long UserId, long CategoryId) : IRequest<Domain.Entities.Expense>;
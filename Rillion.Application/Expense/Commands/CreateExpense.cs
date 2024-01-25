using MediatR;

namespace Rillion.Application.Expense.Commands;

public record CreateExpense : IRequest<Domain.Entities.Expense>
{
    public long UserId { get; set; }
    public long Amount { get; set; }
    public long CategoryId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
}
using MediatR;

public record CreateExpense : IRequest<Expense>
{
    public long UserId { get; set; }
    public long Amount { get; set; }
    public long CategoryId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
}
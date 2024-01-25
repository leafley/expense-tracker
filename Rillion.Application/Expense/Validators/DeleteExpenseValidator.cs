using FluentValidation;

public class DeleteExpenseValidator : AbstractValidator<DeleteExpense>
{
    public DeleteExpenseValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).GreaterThan(0);
    }
}
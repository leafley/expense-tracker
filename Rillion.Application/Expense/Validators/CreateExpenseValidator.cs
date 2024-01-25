using FluentValidation;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Validators;

public class CreateExpenseValidator : AbstractValidator<CreateExpense>
{
    public CreateExpenseValidator()
    {
        RuleFor(n => n.UserId).GreaterThan(0);
        RuleFor(n => n.Amount).GreaterThan(0);
        RuleFor(n => n.CategoryId).GreaterThan(0);
        RuleFor(n => n.Date).NotEqual((DateOnly)default);
        RuleFor(n => n.Description).MaximumLength(200);
    }
}
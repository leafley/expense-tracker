using FluentValidation;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Validation;

namespace Rillion.Application.Expense.Validators;

public class DeleteExpenseValidator : AbstractValidator<DeleteExpense>
{
    public DeleteExpenseValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).MustBeCurrentUser();
    }
}
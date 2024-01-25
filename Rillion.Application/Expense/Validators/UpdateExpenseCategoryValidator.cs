using FluentValidation;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Validation;

namespace Rillion.Application.Expense.Validators;

public class UpdateExpenseCategoryValidator : AbstractValidator<UpdateExpenseCategory>
{
    public UpdateExpenseCategoryValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).MustBeCurrentUser();
        RuleFor(n => n.CategoryId).GreaterThan(0);
    }
}
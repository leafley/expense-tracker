using FluentValidation;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Validators;

public class UpdateExpenseCategoryValidator : AbstractValidator<UpdateExpenseCategory>
{
    public UpdateExpenseCategoryValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).GreaterThan(0);
        RuleFor(n => n.CategoryId).GreaterThan(0);
    }
}
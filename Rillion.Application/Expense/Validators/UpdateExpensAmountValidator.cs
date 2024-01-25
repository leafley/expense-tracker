using FluentValidation;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Validation;

namespace Rillion.Application.Expense.Validators;

public class UpdateExpenseAmountValidator : AbstractValidator<UpdateExpenseAmount>
{
    public UpdateExpenseAmountValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).MustBeCurrentUser();
        RuleFor(n => n.Amount).GreaterThan(0);
    }
}
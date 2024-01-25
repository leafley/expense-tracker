using FluentValidation;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Validators;

public class UpdateExpenseAmountValidator : AbstractValidator<UpdateExpenseAmount>
{
    public UpdateExpenseAmountValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).GreaterThan(0);
        RuleFor(n => n.Amount).GreaterThan(0);
    }
}
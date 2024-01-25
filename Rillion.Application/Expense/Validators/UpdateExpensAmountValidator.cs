using FluentValidation;

public class UpdateExpenseAmountValidator : AbstractValidator<UpdateExpenseAmount>
{
    public UpdateExpenseAmountValidator()
    {
        RuleFor(n => n.Id).GreaterThan(0);
        RuleFor(n => n.UserId).GreaterThan(0);
        RuleFor(n => n.Amount).GreaterThan(0);
    }
}
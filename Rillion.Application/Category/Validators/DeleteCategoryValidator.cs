using FluentValidation;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategory>
{
    public DeleteCategoryValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
    }
}
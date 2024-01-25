using FluentValidation;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
    }
}
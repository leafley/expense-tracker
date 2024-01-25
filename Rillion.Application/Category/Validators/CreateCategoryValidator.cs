using FluentValidation;
using Rillion.Application.Category.Commands;

namespace Rillion.Application.Category.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
    }
}
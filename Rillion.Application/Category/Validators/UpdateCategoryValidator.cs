using FluentValidation;
using Rillion.Application.Category.Commands;

namespace Rillion.Application.Category.Validators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
{
    public UpdateCategoryValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Name).NotEmpty();
    }
}
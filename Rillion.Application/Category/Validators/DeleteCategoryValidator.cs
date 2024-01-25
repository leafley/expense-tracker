using FluentValidation;
using Rillion.Application.Category.Commands;

namespace Rillion.Application.Category.Validators;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategory>
{
    public DeleteCategoryValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
    }
}
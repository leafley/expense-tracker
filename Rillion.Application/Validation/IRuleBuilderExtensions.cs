using FluentValidation;

namespace Rillion.Application.Validation;

public static class IRuleBuilderExtensions
{
    public static IRuleBuilder<T, long> MustBeCurrentUser<T>(this IRuleBuilder<T, long> ruleBuilder)
    {
        return ruleBuilder.Custom((userId, ctx) =>
        {
            var validationUser = ctx.RootContextData.TryGetValue(nameof(ValidationUser), out var id)
                ? id as long? : null;

            if (validationUser.HasValue && validationUser.Value != userId)
                ctx.AddFailure(new FluentValidation.Results.ValidationFailure(ctx.PropertyPath, "The ID must match the current user"));
        });
    }
}
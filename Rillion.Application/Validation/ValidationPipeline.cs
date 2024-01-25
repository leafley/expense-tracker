using FluentValidation;
using MediatR;

namespace Rillion.Application.Validation;

public class ValidationPipeline<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly long? _validationUserId;

    public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators, ValidationUser validationUser)
    {
        _validators = validators;
        _validationUserId = validationUser.userId;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (!_validators.Any())
            return next();

        var validationContext = new ValidationContext<TRequest>(request);
        validationContext.RootContextData[nameof(ValidationUser)] = _validationUserId;

        var failures = _validators
            .Select(n => n.Validate(validationContext))
            .Where(n => !n.IsValid)
            .SelectMany(n => n.Errors)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return next();
    }
}
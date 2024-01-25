using FluentValidation;
using MediatR;

public class ValidationPipeline<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var failures = _validators
            .Select(n => n.Validate(request))
            .Where(n => !n.IsValid)
            .SelectMany(n => n.Errors)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return next();
    }
}
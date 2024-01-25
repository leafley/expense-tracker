using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Category.Commands;

namespace Rillion.Application.Category.Handlers;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, Domain.Entities.Category?>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Category?> Handle(UpdateCategory request, CancellationToken cancellationToken) =>
        await _repository.UpdateAsync(request.Id, request.Name, cancellationToken);
}
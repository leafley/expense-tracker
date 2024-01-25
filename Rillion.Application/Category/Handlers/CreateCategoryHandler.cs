using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Category.Commands;

namespace Rillion.Application.Category.Handlers;

public class CreateCategoryHandler : IRequestHandler<CreateCategory, Domain.Entities.Category>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Category> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return await _repository.AddAsync(request.Name);
#pragma warning restore CS8604 // Possible null reference argument.
    }
}
using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Category.Commands;

namespace Rillion.Application.Category.Handlers;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, Domain.Entities.Category?>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Category?> Handle(DeleteCategory request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
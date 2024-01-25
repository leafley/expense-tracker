using System.ComponentModel.DataAnnotations;
using MediatR;

public class CreateCategoryHandler : IRequestHandler<CreateCategory, Category>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return await _repository.AddAsync(request.Name);
#pragma warning restore CS8604 // Possible null reference argument.
    }
}
using MediatR;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, Category>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> Handle(UpdateCategory request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(request.Id, request.Name);
    }
}
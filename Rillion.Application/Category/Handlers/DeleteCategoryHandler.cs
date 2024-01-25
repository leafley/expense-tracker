using MediatR;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, Category?>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category?> Handle(DeleteCategory request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
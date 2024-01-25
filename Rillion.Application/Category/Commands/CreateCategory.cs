using MediatR;

public record CreateCategory(string? Name) : IRequest<Category>
{
}
using MediatR;

public record CreateCategory : IRequest<Category>
{
    public string? Name { get; set; }
}
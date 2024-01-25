using MediatR;

public record UpdateCategory(long Id, string Name) : IRequest<Category>;
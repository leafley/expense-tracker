using MediatR;

public record DeleteCategory(long Id) : IRequest<Category>;
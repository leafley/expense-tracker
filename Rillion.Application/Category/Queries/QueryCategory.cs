using MediatR;

public record QueryCategory : IRequest<IEnumerable<Category>>;
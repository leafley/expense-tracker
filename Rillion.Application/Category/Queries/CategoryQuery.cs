using MediatR;

public record CategoryQuery : IRequest<IEnumerable<Category>>;
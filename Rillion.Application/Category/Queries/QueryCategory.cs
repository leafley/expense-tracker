using MediatR;

namespace Rillion.Application.Category.Queries;

public record QueryCategory : IRequest<IEnumerable<Domain.Entities.Category>>;
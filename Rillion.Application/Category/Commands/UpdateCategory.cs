using MediatR;

namespace Rillion.Application.Category.Commands;

public record UpdateCategory(long Id, string Name) : IRequest<Domain.Entities.Category>;
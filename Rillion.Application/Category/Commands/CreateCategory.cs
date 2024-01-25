using MediatR;

namespace Rillion.Application.Category.Commands;

public record CreateCategory(string? Name) : IRequest<Domain.Entities.Category>;
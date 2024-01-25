using MediatR;

namespace Rillion.Application.Category.Commands;

public record DeleteCategory(long Id) : IRequest<Domain.Entities.Category>;
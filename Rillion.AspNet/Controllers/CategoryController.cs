
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rillion.Application.Category.Commands;
using Rillion.Application.Category.Queries;

namespace Rillion.AspNet.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<Domain.Entities.Category> AddAsync([FromBody] CreateCategory command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpPost]
    public async Task<Domain.Entities.Category> UpdateAsync([FromBody] UpdateCategory command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpDelete]
    public async Task<Domain.Entities.Category> DeleteAsync([FromBody] DeleteCategory command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<Domain.Entities.Category>> GetAllAsync(CancellationToken cancellationToken) =>
        await _mediator.Send(new QueryCategory(), cancellationToken);
}
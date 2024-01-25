
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<Category> AddAsync([FromBody] CreateCategory command) =>
        await _mediator.Send(command);

    [HttpPost]
    public async Task<Category> UpdateAsync([FromBody] UpdateCategory command) =>
        await _mediator.Send(command);

    [HttpDelete]
    public async Task<Category> DeleteAsync([FromBody] DeleteCategory command) =>
        await _mediator.Send(command);

    [HttpGet]
    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _mediator.Send(new QueryCategory());
}
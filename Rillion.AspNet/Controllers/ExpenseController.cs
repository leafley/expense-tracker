
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Queries;

namespace Rillion.AspNet.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExpenseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<Domain.Entities.Expense> AddAsync([FromBody] CreateExpense command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpPost("amount")]
    public async Task<Domain.Entities.Expense> UpdateAmountAsync([FromBody] UpdateExpenseAmount command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpPost("category")]
    public async Task<Domain.Entities.Expense> UpdateCategoryAsync([FromBody] UpdateExpenseCategory command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpDelete]
    public async Task<Domain.Entities.Expense> DeleteAsync([FromBody] DeleteExpense command, CancellationToken cancellationToken) =>
        await _mediator.Send(command, cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<Domain.Entities.Expense>> GetAsync(
        [FromQuery] long userId,
        [FromQuery] int page,
        [FromQuery] int? pageSize,
        CancellationToken cancellationToken) =>
        await _mediator.Send(new QueryExpensePage(userId, page, pageSize), cancellationToken);
}
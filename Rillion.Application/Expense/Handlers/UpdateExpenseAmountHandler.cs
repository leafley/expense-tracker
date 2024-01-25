
using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Handlers;

public class UpdateExpenseAmountHandler : IRequestHandler<UpdateExpenseAmount, Domain.Entities.Expense?>
{
    private readonly IExpenseRepository _repository;

    public UpdateExpenseAmountHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Expense?> Handle(UpdateExpenseAmount request, CancellationToken cancellationToken) =>
        await _repository.UpdateAmountAsync(request.Id, request.UserId, request.Amount, cancellationToken);
}
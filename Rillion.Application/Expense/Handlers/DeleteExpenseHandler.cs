using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Handlers;

public class DeleteExpenseHandler : IRequestHandler<DeleteExpense, Domain.Entities.Expense?>
{
    private readonly IExpenseRepository _repository;

    public DeleteExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Expense?> Handle(DeleteExpense request, CancellationToken cancellationToken) =>
        await _repository.DeleteAsync(request.Id, request.UserId, cancellationToken);
}
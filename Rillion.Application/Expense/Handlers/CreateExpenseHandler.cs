using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Handlers;

public class CreateExpenseHandler : IRequestHandler<CreateExpense, Domain.Entities.Expense>
{
    private readonly IExpenseRepository _repository;

    public CreateExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Expense> Handle(CreateExpense request, CancellationToken cancellationToken) =>
        await _repository.AddAsync(new Domain.Entities.Expense
        {
            Amount = request.Amount,
            CategoryId = request.CategoryId,
            Date = request.Date,
            Description = request.Description,
            UserId = request.UserId
        }, cancellationToken);
}
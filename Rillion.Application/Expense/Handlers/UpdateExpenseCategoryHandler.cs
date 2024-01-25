
using MediatR;
using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;

namespace Rillion.Application.Expense.Handlers;

public class UpdateExpenseCategoryHandler : IRequestHandler<UpdateExpenseCategory, Domain.Entities.Expense?>
{
    private readonly IExpenseRepository _repository;

    public UpdateExpenseCategoryHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Expense?> Handle(UpdateExpenseCategory request, CancellationToken cancellationToken) =>
        await _repository.UpdateCategoryIdAsync(request.Id, request.UserId, request.CategoryId, cancellationToken);
}
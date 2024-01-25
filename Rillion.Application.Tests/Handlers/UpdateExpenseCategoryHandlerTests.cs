using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Handlers;

namespace Rillion.Application.Tests.Handlers;

public class UpdateExpenseCategoryHandlerTests
{
    private readonly IExpenseRepository _repository = A.Fake<IExpenseRepository>();
    private readonly UpdateExpenseCategoryHandler _handler;

    public UpdateExpenseCategoryHandlerTests()
    {
        _handler = new UpdateExpenseCategoryHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var command = new UpdateExpenseCategory(1, 1, 2);
        A.CallTo(() => _repository.UpdateCategoryIdAsync(command.Id, command.UserId, command.CategoryId, A<CancellationToken>._))
            .Returns(new Domain.Entities.Expense { Id = command.Id, UserId = command.UserId, CategoryId = command.CategoryId });

        var result = await _handler.Handle(command, CancellationToken.None);

        result?.Id.Should().Be(command.Id);
        result?.UserId.Should().Be(command.UserId);
        result?.CategoryId.Should().Be(command.CategoryId);
    }

    [Fact]
    public async Task Handle_CategoryNotFound_ReturnsNull()
    {
        var command = new UpdateExpenseCategory(1, 1, 2);
        A.CallTo(() => _repository.UpdateCategoryIdAsync(command.Id, command.UserId, command.CategoryId, A<CancellationToken>._))
            .Returns(null as Domain.Entities.Expense);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }
}
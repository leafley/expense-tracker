using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Handlers;

namespace Rillion.Application.Tests.Handlers;

public class DeleteExpenseHandlerTests
{
    private readonly IExpenseRepository _repository = A.Fake<IExpenseRepository>();
    private readonly DeleteExpenseHandler _handler;

    public DeleteExpenseHandlerTests()
    {
        _handler = new DeleteExpenseHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var command = new DeleteExpense(1, 1);
        A.CallTo(() => _repository.DeleteAsync(command.Id, command.UserId, A<CancellationToken>._))
            .Returns(new Domain.Entities.Expense { Id = command.Id, UserId = command.UserId });

        var result = await _handler.Handle(command, CancellationToken.None);

        result?.Id.Should().Be(command.Id);
        result?.UserId.Should().Be(command.UserId);
    }

    [Fact]
    public async Task Handle_ExpenseDoesntExist_RetunsNull()
    {
        var command = new DeleteExpense(1, 1);
        A.CallTo(() => _repository.DeleteAsync(command.Id, command.UserId, A<CancellationToken>._))
            .Returns(null as Domain.Entities.Expense);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }
}
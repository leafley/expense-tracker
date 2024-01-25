using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Handlers;

namespace Rillion.Application.Tests.Handlers;

public class UpdateExpenseAmountHandlerTests
{
    private readonly IExpenseRepository _repository = A.Fake<IExpenseRepository>();
    private readonly UpdateExpenseAmountHandler _handler;

    public UpdateExpenseAmountHandlerTests()
    {
        _handler = new UpdateExpenseAmountHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var command = new UpdateExpenseAmount(1, 1, 50);
        A.CallTo(() => _repository.UpdateAmountAsync(command.Id, command.UserId, command.Amount, A<CancellationToken>._))
            .Returns(new Domain.Entities.Expense { Id = command.Id, UserId = command.UserId, Amount = command.Amount });

        var result = await _handler.Handle(command, CancellationToken.None);

        result?.Id.Should().Be(command.Id);
        result?.UserId.Should().Be(command.UserId);
        result?.Amount.Should().Be(command.Amount);
    }

    [Fact]
    public async Task Handle_CategoryNotFound_ReturnsNull()
    {
        var command = new UpdateExpenseAmount(1, 1, 50);
        A.CallTo(() => _repository.UpdateAmountAsync(command.Id, command.UserId, command.Amount, A<CancellationToken>._))
            .Returns(null as Domain.Entities.Expense);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }
}
using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Handlers;

namespace Rillion.Application.Tests.Handlers;

public class CreateExpenseHandlerTests
{
    private readonly IExpenseRepository _repository = A.Fake<IExpenseRepository>();
    private readonly CreateExpenseHandler _handler;

    public Domain.Entities.Expense SomeExpense => new Domain.Entities.Expense
    {
        Amount = 50,
        CategoryId = 1,
        Date = DateOnly.MaxValue,
        Description = "Some description",
        Id = 1,
        UserId = 1
    };

    public CreateExpenseHandlerTests()
    {
        _handler = new CreateExpenseHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var expected = SomeExpense;
        var command = new CreateExpense
        {
            Amount = expected.Amount,
            CategoryId = expected.CategoryId,
            Date = expected.Date,
            Description = expected.Description,
            UserId = expected.UserId
        };

        A.CallTo(() => _repository.AddAsync(A<Domain.Entities.Expense>._, A<CancellationToken>._))
            .Returns(expected);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeEquivalentTo(expected);
    }
}
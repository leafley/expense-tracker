using Rillion.Application.Abstractions;
using Rillion.Application.Expense.Handlers;
using Rillion.Application.Expense.Queries;

namespace Rillion.Application.Tests.Handlers;

public class QueryExpensePageHandlerTests
{
    private readonly IExpenseRepository _repository = A.Fake<IExpenseRepository>();
    private readonly QueryExpensePageHandler _handler;

    public QueryExpensePageHandlerTests()
    {
        _handler = new QueryExpensePageHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        Domain.Entities.Expense[] expected = [new() { Id = 1 }, new() { Id = 2 }];
        var command = new QueryExpensePage(1, 1, 10);
        A.CallTo(() => _repository.GetPageAsync(A<long>._, A<int>._, A<int>._, A<CancellationToken>._))
            .Returns(expected);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeEquivalentTo(expected);
    }
}
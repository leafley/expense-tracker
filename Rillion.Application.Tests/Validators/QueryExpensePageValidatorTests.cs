using Rillion.Application.Expense.Queries;
using Rillion.Application.Expense.Validators;

namespace Rillion.Application.Tests.Validators;

public class QueryExpensePageValidatorTests
{
    IValidator<QueryExpensePage> _validator;

    public QueryExpensePageValidatorTests()
    {
        _validator = new QueryExpensePageValidator();
    }

    [Fact]
    public void Validate_ValidCommand_NoErrors()
    {
        var command = new QueryExpensePage(1, 0, 500);

        var result = _validator.Validate(command);

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidUserId_AddUserIdError(long userId)
    {
        var command = new QueryExpensePage(userId, 0, 500);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.UserId));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Validate_InvalidPage_AddPageError(int page)
    {
        var command = new QueryExpensePage(1, page, 500);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Page));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(int.MinValue)]
    public void Validate_InvalidAmount_AddAmountError(int pageSize)
    {
        var command = new QueryExpensePage(1, 0, pageSize);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.PageSize));
    }
}
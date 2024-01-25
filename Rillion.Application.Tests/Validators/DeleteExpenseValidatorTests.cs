using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Validators;

namespace Rillion.Application.Tests.Validators;

public class DeleteExpenseValidatorTests
{
    IValidator<DeleteExpense> _validator;

    public DeleteExpenseValidatorTests()
    {
        _validator = new DeleteExpenseValidator();
    }

    [Fact]
    public void Validate_ValidCommand_NoErrors()
    {
        var command = new DeleteExpense(1, 1);

        var result = _validator.Validate(command);

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidUserId_AddUserIdError(long userId)
    {
        var command = new DeleteExpense(1, userId);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.UserId));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidId_AddIdError(long id)
    {
        var command = new DeleteExpense(id, 1);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Id));
    }
}
using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Validators;

namespace Rillion.Application.Tests.Validators;

public class UpdateExpenseAmountValidatorTests
{
    IValidator<UpdateExpenseAmount> _validator;

    public UpdateExpenseAmountValidatorTests()
    {
        _validator = new UpdateExpenseAmountValidator();
    }

    [Fact]
    public void Validate_ValidCommand_NoErrors()
    {
        var command = new UpdateExpenseAmount(1, 1, 500);

        var result = _validator.Validate(command);

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidAmount_AddAmountError(long amount)
    {
        var command = new UpdateExpenseAmount(1, 1, amount);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Amount));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidUserId_AddUserIdError(long userId)
    {
        var command = new UpdateExpenseAmount(1, userId, 500);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.UserId));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidId_AddIdError(long id)
    {
        var command = new UpdateExpenseAmount(id, 1, 500);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Id));
    }
}
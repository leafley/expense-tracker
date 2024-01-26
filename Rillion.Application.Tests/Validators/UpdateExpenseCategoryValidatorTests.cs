using Rillion.Application.Expense.Commands;
using Rillion.Application.Expense.Validators;

namespace Rillion.Application.Tests.Validators;

public class UpdateExpenseCategoryValidatorTests
{
    IValidator<UpdateExpenseCategory> _validator;

    public UpdateExpenseCategoryValidatorTests()
    {
        _validator = new UpdateExpenseCategoryValidator();
    }

    [Fact]
    public void Validate_ValidCommand_NoErrors()
    {
        var command = new UpdateExpenseCategory(1, 1, 1);

        var result = _validator.Validate(command);

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidAmount_AddAmountError(long categoryId)
    {
        var command = new UpdateExpenseCategory(1, 1, categoryId);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.CategoryId));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidId_AddIdError(long id)
    {
        var command = new UpdateExpenseCategory(id, 1, 1);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Id));
    }
}
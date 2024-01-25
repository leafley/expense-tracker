namespace Rillion.Application.Tests.Validators;

public class CreateExpenseValidatorTests
{
    IValidator<CreateExpense> _validator;

    public CreateExpense CreateSomeExpense => new CreateExpense
    {
        Amount = 50,
        CategoryId = 1,
        Date = DateOnly.MaxValue,
        Description = "Some description",
        UserId = 1
    };

    public CreateExpenseValidatorTests()
    {
        _validator = new CreateExpenseValidator();
    }

    [Fact]
    public void Validate_ValidCommand_NoErrors()
    {
        var result = _validator.Validate(CreateSomeExpense);

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidAmount_AddAmountError(long amount)
    {
        var command = CreateSomeExpense with { Amount = amount };

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Amount));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidCategoryId_AddCategoryIdError(long categoryId)
    {
        var command = CreateSomeExpense with { CategoryId = categoryId };

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.CategoryId));
    }

    [Fact]
    public void Validate_DefaultDate_AddDateError()
    {
        var command = CreateSomeExpense with { Date = default };

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Date));
    }

    [Fact]
    public void Validate_LongDescription_AddDescriptionError()
    {
        var command = CreateSomeExpense with { Description = new string('*', 250) };

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Description));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidUserId_AddUserIdError(long userId)
    {
        var command = CreateSomeExpense with { UserId = userId };

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.UserId));
    }
}
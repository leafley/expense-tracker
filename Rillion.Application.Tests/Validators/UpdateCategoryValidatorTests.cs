namespace Rillion.Application.Tests.Validators;

public class UpdateCategoryValidatorTests
{
    IValidator<UpdateCategory> _validator;

    public UpdateCategoryValidatorTests()
    {
        _validator = new UpdateCategoryValidator();
    }

    [Fact]
    public void Validate_Valid_NoErrors()
    {
        var result = _validator.Validate(new UpdateCategory(1, "SomeName"));

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Validate_InvalidName_AddNameError(string name)
    {
        var command = new UpdateCategory(1, name);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Name));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidId_AddNameError(long id)
    {
        var command = new UpdateCategory(id, "SomeName");

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Id));
    }
}
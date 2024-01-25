namespace Rillion.Application.Tests.Validators;

public class CreateCategoryValidatorTests
{
    IValidator<CreateCategory> _validator;

    public CreateCategoryValidatorTests()
    {
        _validator = new CreateCategoryValidator();    
    }

    [Fact]
    public void Validate_ValidName_NoErrors()
    {
        var result = _validator.Validate(new CreateCategory("SomeName"));

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Validate_InvalidName_AddNameError(string name)
    {
        var command = new CreateCategory(name);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Name));
    }
}
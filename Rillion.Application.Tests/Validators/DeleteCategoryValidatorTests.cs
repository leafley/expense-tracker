using Rillion.Application.Category.Commands;
using Rillion.Application.Category.Validators;

namespace Rillion.Application.Tests.Validators;

public class DeleteCategoryValidatorTests
{
    IValidator<DeleteCategory> _validator;

    public DeleteCategoryValidatorTests()
    {
        _validator = new DeleteCategoryValidator();
    }

    [Fact]
    public void Validate_Valid_NoErrors()
    {
        var result = _validator.Validate(new DeleteCategory(1));

        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(long.MinValue)]
    public void Validate_InvalidId_AddNameError(long id)
    {
        var command = new DeleteCategory(id);

        var result = _validator.Validate(command);

        result.Errors.Should().Contain(n => n.PropertyName == nameof(command.Id));
    }
}
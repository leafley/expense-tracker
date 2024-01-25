using Rillion.Application.Abstractions;
using Rillion.Application.Category.Commands;
using Rillion.Application.Category.Handlers;

namespace Rillion.Application.Tests.Handlers;

public class DeleteCategoryHandlerTests
{
    private readonly ICategoryRepository _repository = A.Fake<ICategoryRepository>();
    private readonly DeleteCategoryHandler _handler;

    public DeleteCategoryHandlerTests()
    {
        _handler = new DeleteCategoryHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var command = new DeleteCategory(1);
        A.CallTo(() => _repository.DeleteAsync(command.Id))
            .Returns(new Domain.Entities.Category { Id = command.Id, Name = "SomeName" });

        var result = await _handler.Handle(command, CancellationToken.None);

        result?.Id.Should().Be(command.Id);
        result?.Name.Should().Be("SomeName");
    }

    [Fact]
    public async Task Handle_CategoryDoesntExist_RetunsNull()
    {
        var command = new DeleteCategory(1);
        A.CallTo(() => _repository.DeleteAsync(command.Id))
            .Returns(null as Domain.Entities.Category);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }
}
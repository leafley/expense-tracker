public class UpdateCategoryHandlerTests
{
    private readonly ICategoryRepository _repository = A.Fake<ICategoryRepository>();
    private readonly UpdateCategoryHandler _handler;

    public UpdateCategoryHandlerTests()
    {
        _handler = new UpdateCategoryHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var command = new UpdateCategory(1, "NewName");
        A.CallTo(() => _repository.UpdateAsync(command.Id, A<string>._))
            .ReturnsLazily((long id, string name) => new Category { Id = id, Name = name });

        var result = await _handler.Handle(command, CancellationToken.None);

        result?.Name.Should().Be(command.Name);
    }

    [Fact]
    public async Task Handle_CategoryNotFound_ReturnsNull()
    {
        var command = new UpdateCategory(1, "NewName");
        A.CallTo(() => _repository.UpdateAsync(command.Id, A<string>._))
            .Returns(null as Category);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }
}
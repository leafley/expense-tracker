public class CreateCategoryHandlerTests
{
    private readonly ICategoryRepository _repository = A.Fake<ICategoryRepository>();
    private readonly CreateCategoryHandler _handler;

    public CreateCategoryHandlerTests()
    {
        _handler = new CreateCategoryHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        var expected = "SomeName";
        A.CallTo(() => _repository.AddAsync(A<string>._))
            .Returns(new Category { Id = 1, Name = expected });

        var result = await _handler.Handle(new CreateCategory { Name = expected }, CancellationToken.None);

        result.Name.Should().Be(expected);
    }
}
public class QueryCategoryHandlerTests
{
    private readonly ICategoryRepository _repository = A.Fake<ICategoryRepository>();
    private readonly QueryCategoryHandler _handler;

    public QueryCategoryHandlerTests()
    {
        _handler = new QueryCategoryHandler(_repository);
    }

    [Fact]
    public async Task Handle_ValidCommand_RetunsDomainType()
    {
        Category[] expected = [new() { Id = 1, Name = "SomeCategory" }, new() { Id = 2, Name = "SomeOtherCategory" }];
        var command = new QueryCategory();
        A.CallTo(() => _repository.GetAllAsync())
            .Returns(expected);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeEquivalentTo(expected);
    }
}
namespace KustoQueryBuilder.UnitTests;

public class QueryTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Query_EmptyTable_ShouldThrowException(string tableName)
    {
        Assert.Throws<ArgumentException>(() => new Query(tableName));
    }
}
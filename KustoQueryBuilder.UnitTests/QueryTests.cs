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

    [Fact]
    public void Query_Where_In_ShouldBeValid()
    {
        var q = new Query("Table1")
            .WhereIn("Col1", new[] { "A", "B", "C" })
            .Compile();

        
    }
}
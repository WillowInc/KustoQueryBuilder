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
        var actualQuery = new Query("Table1")
            .WhereIn("Col1", new[] { "A", "B", "C" })
            .Compile();

        var expectedQuery = "Table1\n" + @" | where Col1 in (""A"", ""B"", ""C"")";

        Assert.Equal(expectedQuery, actualQuery);
        
    }
}
namespace KustoQueryBuilder.UnitTests;

public class OrderByTests
{
    [Fact]
    public void OrderBy_ColumnArray_ShouldBeValid()
    {
        var query = new Query("table")
            .OrderBy("col1", "col2")
            .Compile();

        Assert.Equal("table\n | order by col1, col2", query);
    }

    [Fact]
    public void OrderBy_EmptyParameters_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Query("table").OrderBy());
    }
}

namespace KustoQueryBuilder.UnitTests;

public class QueryWhereTests
{
    [Fact]
    public void Query_WhereBetweenValidDates_ReturnsQuery()
    {
        var q = new Query("Table1")
            .WhereBetween("Column1", new DateTime(2021, 1, 1), new DateTime(2022, 1, 1));

        var actualQuery = q.Compile();
        var expectedQuery = "Table1\n | where Column1 between (datetime(2021-01-01T00:00:00) .. datetime(2022-01-01T00:00:00))";
        
        Assert.Equal(actualQuery, expectedQuery);
    }
    
    [Fact]
    public void Query_WhereNotBetweenValidDates_ReturnsQuery()
    {
        var q = new Query("Table1")
            .WhereNotBetween("Column1", new DateTime(2021, 1, 1), new DateTime(2022, 1, 1));

        var actualQuery = q.Compile();
        var expectedQuery = "Table1\n | where Column1 !between (datetime(2021-01-01T00:00:00) .. datetime(2022-01-01T00:00:00))";
        
        Assert.Equal(actualQuery, expectedQuery);
    }
}
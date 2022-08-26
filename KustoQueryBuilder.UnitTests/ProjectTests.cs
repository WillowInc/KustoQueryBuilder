namespace KustoQueryBuilder.UnitTests;

public class ProjectTests
{
    [Fact]
    public void Project_MultipleColumns_ShouldBeValid()
    {
        var qry = new Query("table")
            .Project("col1", "col2")
            .Compile();

        Assert.Equal("table\n | project col1, col2", qry);
    }

    [Fact]
    public void Project_ColumnArray_ShouldBeValid()
    {
        var cols = new[] { "col1", "col2" };
        var qry = new Query("table")
            .Project(cols)
            .Compile();

        Assert.Equal("table\n | project col1, col2", qry);
    }

    [Fact]
    public void Project_EmptyColumns_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Query("table").Project());
    }
}

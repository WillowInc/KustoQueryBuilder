namespace KustoQueryBuilder.UnitTests;

public class ProjectTests
{
    // TODO: Add unit test when Compile is added
    [Fact]
    public void Project_MultipleColumns_ShouldBeValid()
    {
        var qry = new Query("table").Project("col1", "col2");
    }

    // TODO: Add unit test when Compile is added
    [Fact]
    public void Project_ColumnArray_ShouldBeValid()
    {
        var cols = new[] { "col1", "col2" };
        var qry = new Query("table").Project(cols);
    }

    [Fact]
    public void Project_EmptyColumns_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Query("table").Project());
    }
}

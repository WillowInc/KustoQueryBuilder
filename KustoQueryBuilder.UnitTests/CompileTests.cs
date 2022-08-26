using AutoFixture;
using FluentAssertions;

namespace KustoQueryBuilder.UnitTests;
public class CompileTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void CompilesQueryOnly()
    {
        string tableName = _fixture.Create<string>();
        Query query = new(tableName);

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be(tableName);
    }

    [Fact]
    public void CompilesWhere()
    {
        Query query = new("table");
        query.Where("column1", "value 1");

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | where column1 = \"value 1\"");
    }

    [Fact]
    public void CompilesWhereIn()
    {
        Query query = new("table");
        query.WhereIn("column1", new List<string> { "value 1", "value 2" });

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | where column1 in (\"value 1\", \"value 2\")");
    }

    [Fact]
    public void CompilesWhereBetween()
    {
        Query query = new("table");
        query.WhereBetween("column1", "value 1", "value 2");

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | where column1 between (\"value 1\" .. \"value 2\")");
    }

    [Fact]
    public void CompilesWhereNotBetween()
    {
        Query query = new("table");
        query.WhereNotBetween("column1", "value 1", "value 2");

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | where column1 !between (\"value 1\" .. \"value 2\")");
    }

    [Fact]
    public void CompilesProject()
    {
        Query query = new("table");
        query.Project("column1", "column2");

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | project column1, column2");
    }

    [Fact]
    public void CompilesOrderBy()
    {
        Query query = new("table");
        query.OrderBy("column1", "column2", "column3");

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | order by column1 asc, column2 asc, column3 asc");
    }

    [Fact]
    public void CompilesOrderByDesc()
    {
        Query query = new("table");
        query.OrderByDesc("column1", "column2", "column3");

        var compiledQuery = query.Compile();

        compiledQuery.Should().Be("table\n | order by column1 desc, column2 desc, column3 desc");
    }
}

using KustoQueryBuilder.Clauses;

namespace KustoQueryBuilder;

public partial class Query
{
    public Query Project(params string[] columns)
    {
        return Project(columns.AsEnumerable());
    }

    public Query Project(IEnumerable<string> columns)
    {
        _clauses.Add(new ProjectClause(columns));

        return this;
    }
}

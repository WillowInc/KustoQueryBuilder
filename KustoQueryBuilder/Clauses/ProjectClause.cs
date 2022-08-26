namespace KustoQueryBuilder.Clauses;

public class ProjectClause : AbstractClause
{
    public IEnumerable<string> Columns { get; }

    public ProjectClause(IEnumerable<string> columns)
    {
        if (!columns.Any())
        {
            throw new ArgumentException("columns is required", nameof(columns));
        }

        Columns = columns;
    }
}

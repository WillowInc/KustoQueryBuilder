using KustoQueryBuilder.Clauses;

namespace KustoQueryBuilder;
public partial class Query
{
    public string TableName { get; }
    private readonly List<AbstractClause> _clauses = new();

    public Query(string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName))
        {
            throw new ArgumentException("tableName parameter cannot be empty", nameof(tableName));
        }

        TableName = tableName;
    }
}

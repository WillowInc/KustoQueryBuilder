using KustoQueryBuilder.Clauses;

namespace KustoQueryBuilder;
public partial class Query
{
    public string TableName { get; }
    private List<AbstractClause> _clauses = new();

    public Query(string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName))
        {
            throw new ArgumentException(nameof(tableName));
        }
        TableName = tableName;
    }

    public Query Where(string column, string op, string value)
    {

        _clauses.Add(new BasicCondition(column, op, value));

        return this;
    }
}

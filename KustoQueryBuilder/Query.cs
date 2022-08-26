namespace KustoQueryBuilder;
public partial class Query
{
    public string TableName { get; }
    private Dictionary<Operations, Parameter> _operationParameters = new();

    public Query(string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName))
        {
            throw new ArgumentException(nameof(tableName));
        }
        TableName = tableName;
    }

    public Query Where(string column, string value)
    {

        _operationParameters.Add(Operations.Where, new WhereParameter(column, value));

        return this;
    }
}

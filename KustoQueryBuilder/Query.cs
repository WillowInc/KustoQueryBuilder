namespace KustoQueryBuilder;
public partial class Query
{
    public string TableName { get; }
    private Dictionary<string, Parameter> OperationParameters = new();

    public Query(string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName))
        {
            throw new ArgumentNullException();
        }
        TableName = tableName;
    }

    public Query Where(string column, string value)
    {
        return this;
    }
}

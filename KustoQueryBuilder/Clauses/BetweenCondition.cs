namespace KustoQueryBuilder.Clauses;

public class BetweenCondition : AbstractClause
{
    public string Column { get; }
    public string FromValue { get; }
    public string ToValue { get; }

    public BetweenCondition(string column, string fromValue, string toValue)
    {
        if (string.IsNullOrEmpty(column))
        {
            throw new ArgumentNullException(nameof(column));
        }

        if (string.IsNullOrEmpty(fromValue))
        {
            throw new ArgumentNullException(nameof(fromValue));
        }

        ArgumentNullException.ThrowIfNull(fromValue);
        ArgumentNullException.ThrowIfNull(toValue);

        Column = column;
        FromValue = fromValue;
        ToValue = toValue;
    }
}
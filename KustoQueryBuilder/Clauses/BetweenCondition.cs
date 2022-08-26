namespace KustoQueryBuilder.Clauses;

public class BetweenClause : AbstractClause
{
    public string Column { get; }
    public string LeftRange { get; }
    public string RightRange { get; }
    public bool Not { get; }

    public BetweenClause(string column, string fromValue, string toValue, bool not = false)
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
        RightRange = fromValue;
        LeftRange = toValue;
        Not = not;
    }
}

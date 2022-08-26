namespace KustoQueryBuilder.Clauses;

public class BetweenClause : AbstractClause
{
    public string Column { get; }
    public DateTime LeftRange { get; }
    public DateTime RightRange { get; }
    public bool Not { get; }

    public BetweenClause(string column, DateTime fromValue, DateTime toValue, bool not = false)
    {
        if (string.IsNullOrEmpty(column))
        {
            throw new ArgumentNullException(nameof(column));
        }

        ArgumentNullException.ThrowIfNull(fromValue);
        ArgumentNullException.ThrowIfNull(toValue);

        if (fromValue > toValue)
        {
            throw new ArgumentException("From date should be before To date");
        }

        Column = column;
        RightRange = fromValue;
        LeftRange = toValue;
        Not = not;
    }
}

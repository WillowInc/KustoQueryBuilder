namespace KustoQueryBuilder.Clauses;

public class BetweenClause : AbstractClause
{
    public string Column { get; }
    public DateTime LeftRange { get; }
    public DateTime RightRange { get; }
    public bool Not { get; }

    public BetweenClause(string column, DateTime leftRange, DateTime rightRange, bool not = false)
    {
        if (string.IsNullOrEmpty(column))
        {
            throw new ArgumentException("column is required", nameof(column));
        }

        ArgumentNullException.ThrowIfNull(leftRange);
        ArgumentNullException.ThrowIfNull(rightRange);

        if (rightRange < leftRange)
        {
            throw new ArgumentException("rightRange should be before or equal to leftRange");
        }

        Column = column;
        LeftRange = leftRange;
        RightRange = rightRange;
        Not = not;
    }
}

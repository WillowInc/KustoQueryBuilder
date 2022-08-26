namespace KustoQueryBuilder.Clauses;

public class BetweenClause : AbstractClause
{
    public string Column { get; }
    public string LeftRange { get; }
    public string RightRange { get; }
    public bool Not { get; }

    public BetweenClause(string column, string leftRange, string rightRange, bool not = false)
    {
        if (string.IsNullOrEmpty(column))
        {
            throw new ArgumentNullException(nameof(column));
        }

        if (string.IsNullOrEmpty(leftRange))
        {
            throw new ArgumentNullException(nameof(leftRange));
        }

        ArgumentNullException.ThrowIfNull(leftRange);
        ArgumentNullException.ThrowIfNull(rightRange);

        Column = column;
        LeftRange = leftRange;
        RightRange = rightRange;
        Not = not;
    }
}

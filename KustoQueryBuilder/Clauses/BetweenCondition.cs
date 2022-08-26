namespace KustoQueryBuilder.Clauses;

public class BetweenCondition : AbstractClause
{
    public string Column { get; }
    public DateTime FromDate { get; }
    public DateTime ToDate { get; }
    public bool Not { get; }

    public BetweenCondition(string column, DateTime fromDate, DateTime toDate, bool not = false)
    {
        if (string.IsNullOrEmpty(column))
        {
            throw new ArgumentNullException(nameof(column));
        }

        ArgumentNullException.ThrowIfNull(fromDate);
        ArgumentNullException.ThrowIfNull(toDate);

        if (fromDate > toDate)
        {
            throw new ArgumentException("From date cannot be before To date");
        }

        Column = column;
        FromDate = fromDate;
        ToDate = toDate;
        Not = not;
    }
}

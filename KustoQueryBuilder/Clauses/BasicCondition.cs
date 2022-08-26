namespace KustoQueryBuilder.Clauses;

public class BasicCondition : AbstractClause
{
    public string Column { get; }
    public string Operator { get; set; }
    public string Value { get; }

    public BasicCondition(string column, string op, string value)
    {
        if (string.IsNullOrEmpty(column))
        {
            throw new ArgumentNullException(nameof(column));
        }

        if (string.IsNullOrEmpty(op))
        {
            throw new ArgumentNullException(nameof(op));
        }

        ArgumentNullException.ThrowIfNull(value);

        Column = column;
        Operator = op;
        Value = value;
    }
}

namespace KustoQueryBuilder;

public class WhereParameter : Parameter
{
    public string Column { get; }
    public string Value { get; }

    public WhereParameter(string column, string value)
    {
        if(string.IsNullOrEmpty(column))
        {
            throw new ArgumentNullException(nameof(column));
        }

        ArgumentNullException.ThrowIfNull(value);

        Column = column;
        Value = value;
    }
}
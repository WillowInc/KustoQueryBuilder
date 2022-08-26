using KustoQueryBuilder;

public class Parameter
{
    public Parameter()
    {
    }
}

public class WhereParameter : Parameter
{
    public string Column { get; set; }
    public string Value { get; set; }
}
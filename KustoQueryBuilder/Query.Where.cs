using KustoQueryBuilder.Clauses;

namespace KustoQueryBuilder;

public partial class Query
{

    public Query Where(string column, string value)
    {
        return Where(column, Operator.EqualTo, value);
    }

    public Query Where(string column, string op, string value)
    {
        _clauses.Add(new BasicCondition(column, op, value));

        return this;
    }

    public Query WhereIn(string column, List<string> values)
    {
        _clauses.Add(new InClause(column, values));

        return this;
    }
}

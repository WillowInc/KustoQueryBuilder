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
        _clauses.Add(new WhereClause(column, op, value));

        return this;
    }
    public Query WhereBetween(string column, DateTime leftRange, DateTime rightRange)
    {
        _clauses.Add(new BetweenClause(column, leftRange, rightRange));

        return this;
    }
    public Query WhereNotBetween(string column, DateTime leftRange, DateTime rightRange)
    {
        _clauses.Add(new BetweenClause(column, leftRange, rightRange, true));

        return this;
    }    

    public Query WhereIn(string column, IEnumerable<string> values)
    {
        _clauses.Add(new InClause(column, values));

        return this;
    }

    public Query WhereNotIn(string column, IEnumerable<string> values, bool not)
    {
        
        _clauses.Add(new InClause(column, values, not));
       
        return this;
    }
}

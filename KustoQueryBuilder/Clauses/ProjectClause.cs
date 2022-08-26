namespace KustoQueryBuilder.Clauses;

public class ProjectClause : AbstractClause
{
    public string[] Columns { get; }
}

public class InClause : AbstractClause
{
    public string Column { get; }
    public List<string> Values { get; }
}

public class BetweenClause : AbstractClause
{
    public string Column { get; }
    public DateTime LeftRange { get; }
    public DateTime RightRange { get; }
}

public class NotBetweenClause : AbstractClause
{
    public string Column { get; }
    public DateTime LeftRange { get; }
    public DateTime RightRange { get; }
}

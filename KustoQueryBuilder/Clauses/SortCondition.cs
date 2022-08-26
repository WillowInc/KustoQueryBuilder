namespace KustoQueryBuilder.Clauses;

internal class SortCondition : AbstractClause
{
    public SortCondition(bool isDescending, string[] sortColums)
    {
        IsDescending = isDescending;
        SortColums = sortColums;
    }

    public bool IsDescending { get; }
    public string[] SortColums { get; }
}

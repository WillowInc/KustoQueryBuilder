namespace KustoQueryBuilder.Clauses;

internal class SortClause : AbstractClause
{
    public SortClause(bool isDescending, string[] sortColums)
    {
        IsDescending = isDescending;
        SortColums = sortColums;
    }

    public bool IsDescending { get; }
    public string[] SortColums { get; }
}

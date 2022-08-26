using KustoQueryBuilder.Clauses;

namespace KustoQueryBuilder;

public partial class Query
{
    public Query OrderBy(params string[] sortParameters) => Order(false, sortParameters);

    public Query OrderByDesc(params string[] sortParameters) => Order(true, sortParameters);

    private Query Order(bool isDescending, string[] sortParameters)
    {
        if(sortParameters == null || !sortParameters.Any())
        {
            throw new ArgumentException("You must supply at least one sort parameter.");
        }
        _clauses.Add(new SortCondition(isDescending, sortParameters));
        return this;
    }
}

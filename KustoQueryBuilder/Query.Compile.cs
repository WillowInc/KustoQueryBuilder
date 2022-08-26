using KustoQueryBuilder.Clauses;
using System.Text;

namespace KustoQueryBuilder;
public partial class Query
{
    private StringBuilder _queryBuilder = new();

    public string Compile()
    {
        Append(TableName, false);

        foreach (var clause in _clauses)
        {
            // Todo: Validate order of clauses
            AppendClause(clause);
        }

        return _queryBuilder.ToString();
    }

    private void AppendClause(AbstractClause clause)
    {
        switch (clause)
        {
            case WhereClause whereClause:
                AppendWhereClause(whereClause);
                break;

            case ProjectClause projectClause:
                AppendProjectClause(projectClause);
                break;

            case InClause inClause:
                AppendInClause(inClause);
                break;

            case BetweenClause betweenClause:
                AppendBetweenClause(betweenClause);
                break;

            case NotBetweenClause notBetweenClause:
                AppendNotBetweenClause(notBetweenClause);
                break;

            default:
                throw new NotImplementedException();
        }
    }

    private void AppendNotBetweenClause(NotBetweenClause notBetweenClause)
    {
        Append($"where {notBetweenClause.Column} !between ({notBetweenClause.LeftRange} .. {notBetweenClause.RightRange})");
    }

    private void AppendBetweenClause(BetweenClause betweenClause)
    {
        Append($"where {betweenClause.Column} between ({betweenClause.LeftRange} .. {betweenClause.RightRange})");
    }

    private void AppendInClause(InClause inClause)
    {
        Append($"where {inClause.Column} in ({string.Join(", ", inClause.Values)})");
    }

    private void AppendProjectClause(ProjectClause projectClause)
    {
        Append($"project {string.Join(", ", projectClause.Columns)}");
    }

    private void AppendWhereClause(WhereClause whereClause)
    {
        Append($"where {whereClause.Column} {whereClause.Operator} {whereClause.Value}");
    }

    private void Append(string section, bool addLeadingPipe = true)
    {
        if (addLeadingPipe)
        {
            _queryBuilder.Append("\n | ");
        }

        _queryBuilder.Append(section);
    }
}

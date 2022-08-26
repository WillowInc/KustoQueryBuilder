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
        Append($"where {notBetweenClause.Column} !between ({FormatValue(notBetweenClause.LeftRange)} .. {FormatValue(notBetweenClause.RightRange)})");
    }

    private void AppendBetweenClause(BetweenClause betweenClause)
    {
        Append($"where {betweenClause.Column} between ({FormatValue(betweenClause.LeftRange)} .. {FormatValue(betweenClause.RightRange)})");
    }

    private void AppendInClause(InClause inClause)
    {
        Append($"where {inClause.Column} in ({string.Join(", ", FormatValue(inClause.Values))})");
    }

    private void AppendProjectClause(ProjectClause projectClause)
    {
        Append($"project {string.Join(", ", projectClause.Columns)}");
    }

    private void AppendWhereClause(WhereClause whereClause)
    {
        Append($"where {whereClause.Column} {whereClause.Operator} {FormatValue(whereClause.Value)}");
    }

    private void Append(string section, bool addLeadingPipe = true)
    {
        if (addLeadingPipe)
        {
            _queryBuilder.Append("\n | ");
        }

        _queryBuilder.Append(section);
    }

    private static string FormatValue<T>(T value)
    {
        switch (value)
        {
            case string stringValue:
                return $"\"{stringValue}\"";

            case DateTime dateTime:
                return $"datetime({dateTime})";

            default:
                var valueAsString = value.ToString();
                return $"\"{valueAsString}\"";
        }
    }
}

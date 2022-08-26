namespace KustoQueryBuilder.Clauses
{

    public class InClause : AbstractClause
    {
        public string Column { get; }
        public List<string> Values { get; }
        public InClause(string column, List<string> values)
        {
            if (string.IsNullOrEmpty(column))
            {
                throw new ArgumentNullException(nameof(column));
            }

            ArgumentNullException.ThrowIfNull(values);

            Column = column;
            Values = values;
        }

    }
}

namespace KustoQueryBuilder.Clauses
{

    public class InClause : AbstractClause
    {
        public string Column { get; }
        public IEnumerable<string> Values { get; }
        public InClause(string column, IEnumerable<string> values)
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

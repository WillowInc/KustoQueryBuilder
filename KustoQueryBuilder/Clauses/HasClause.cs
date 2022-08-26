using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KustoQueryBuilder.Clauses
{
    public class HasClause : AbstractClause
    {
        public string Column { get; }
        public string Value { get; }

        public HasClause(string column, string value)
        {
            if (string.IsNullOrEmpty(column))
            {
                throw new ArgumentException("column is required", nameof(column));
            }

            ArgumentNullException.ThrowIfNull(value);

            Column = column;
            Value = value;
        }
    }
}

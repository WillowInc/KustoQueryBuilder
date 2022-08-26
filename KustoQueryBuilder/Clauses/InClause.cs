using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KustoQueryBuilder.Clauses
{
    
    public class InClause : AbstractClause
    {
        public string Column { get; }
        public List<string> Values { get; set; }
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

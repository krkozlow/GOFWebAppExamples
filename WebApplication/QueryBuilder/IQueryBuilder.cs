using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder
{
    public interface IQueryBuilder
    {
        string Build();
        IQueryBuilder Table(string table);
        IQueryBuilder Columns(string[] columns);

        IQueryBuilder OrderBy(string column);

        IQueryBuilder Top(int top);

        IQueryBuilder Distinct();

        IQueryBuilder Ascending();

        IQueryBuilder Descending();
    }
}

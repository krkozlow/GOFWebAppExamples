using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder
{
    public abstract class QueryBuilder : IQueryBuilder
    {
        protected QueryConfiguration _query;

        public abstract IQueryBuilder Table(string table);

        public abstract IQueryBuilder Columns(string[] columns);

        public abstract IQueryBuilder OrderBy(string column);

        public abstract IQueryBuilder Top(int top);

        public abstract IQueryBuilder Distinct();

        public abstract IQueryBuilder Ascending();

        public abstract IQueryBuilder Descending();

        public abstract string Build();
    }
}

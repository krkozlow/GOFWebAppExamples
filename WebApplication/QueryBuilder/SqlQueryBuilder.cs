using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryBuilder
{
    public class SqlQueryBuilder : QueryBuilder
    {
        private StringBuilder _result = new StringBuilder();

        public override IQueryBuilder Table(string table)
        {
            _query.Table = table;

            return this;
        }

        public override IQueryBuilder Columns(string[] columns)
        {
            _query.Columns = columns;

            return this;
        }

        public override IQueryBuilder OrderBy(string column)
        {
            _query.OrderBy = column;

            return this;
        }

        public override IQueryBuilder Top(int top)
        {
            if (top < 1)
            {
                throw new ArgumentException($"Cannot select top {top} rows");
            }

            _query.Top = top;

            return this;
        }

        public override IQueryBuilder Distinct()
        {
            _query.IsDistinct = true;

            return this;
        }

        public override IQueryBuilder Ascending()
        {
            _query.IsAscending = true;

            return this;
        }

        public override IQueryBuilder Descending()
        {
            _query.IsDescending = true;

            return this;
        }

        public override string Build()
        {
            _result.Append("SELECT ");

            if (_query.IsDistinct)
            {
                _result.Append("DISTINCT ");
            }

            if (_query.Top > 0)
            {
                _result.Append($"TOP {_query.Top} ");
            }

            if (_query.Columns.Any())
            {
                _result.AppendJoin(',', _query.Columns);
                _result.Append(" ");
            }

            if (!String.IsNullOrEmpty(_query.Table))
            {
                _result.Append($"FROM {_query.Table}");
            }

            if (!String.IsNullOrEmpty(_query.OrderBy))
            {
                _result.Append($"ORDER BY {_query.OrderBy}");
            }

            if (_query.IsAscending)
            {
                _result.Append("ASCENDING");
            }

            return _result.ToString();
        }
    }
}
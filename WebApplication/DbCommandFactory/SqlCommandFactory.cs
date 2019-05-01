using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbCommandFactory
{
    public class SqlCommandFactory : IDbCommandFactory
    {
        public IDbCommand CreateSelectCommand(IDbConnection connection, IQueryBuilder query)
        {
            var command = connection.CreateCommand();
            command.CommandText = CreateQuery(query);

            return command;
        }

        private string CreateQuery(IQueryBuilder query)
        {
            return query.Build();
        }
    }
}

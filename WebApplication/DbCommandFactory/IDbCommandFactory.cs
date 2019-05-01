using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbCommandFactory
{
    public interface IDbCommandFactory
    {
        IDbCommand CreateSelectCommand(IDbConnection connection, IQueryBuilder queryBuilder);
    }
}
using DbCommandFactory;
using DbConnectionFactory;
using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbAbstractFactory
{
    public static class DbAbstractFactory
    {
        public static IDbConnectionFactory ConnectionFactory(IDbConnectionFactory connectionFactory)
        {
            return connectionFactory;
        }

        public static IDbCommandFactory CommandFactory(IDbCommandFactory commandFactory)
        {
            return commandFactory;
        }
    }
}
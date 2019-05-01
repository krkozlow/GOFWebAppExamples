using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbConnectionFactory
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection Create(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbConnectionFactory
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create(string connectionString);
    }
}

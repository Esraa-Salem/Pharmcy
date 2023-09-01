using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pharmcy.Attributes
{
    public sealed class SingletonSqlConnection
    {
        private static readonly Lazy<SingletonSqlConnection> lazy =
        new Lazy<SingletonSqlConnection>(() => new SingletonSqlConnection(ConnectionString.constr()));

        public readonly SqlConnection Connection;

        private SingletonSqlConnection(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public static SingletonSqlConnection Instance { get { return lazy.Value; } }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
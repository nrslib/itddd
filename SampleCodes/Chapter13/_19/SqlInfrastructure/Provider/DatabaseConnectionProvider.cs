using System;
using System.Data.SqlClient;

namespace _19.SqlInfrastructure.Provider
{
    public class DatabaseConnectionProvider : IDisposable
    {
        private readonly string connectionString;
        private SqlConnection _connection;

        public DatabaseConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection Connection
        {
            get
            {
                if (_connection != null)
                {
                    return _connection;
                }

                _connection = new SqlConnection(connectionString);
                _connection.Open();

                return _connection;
            }
        }

        public void Dispose() {
            _connection?.Dispose();
        }
    }
}

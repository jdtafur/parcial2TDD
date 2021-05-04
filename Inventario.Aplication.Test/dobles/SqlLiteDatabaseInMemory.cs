using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace Inventario.Application.test.Dobles
{
    public class SqlLiteDatabaseInMemory
    {
        public static DbConnection CreateConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}
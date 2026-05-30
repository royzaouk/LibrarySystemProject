using System.Data.SqlClient;

namespace LibrarySystem
{
    public static class DatabaseHandler
    {
        private static string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=LibrarySystem;Integrated Security=True;";

        public static SqlConnection GetNewConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
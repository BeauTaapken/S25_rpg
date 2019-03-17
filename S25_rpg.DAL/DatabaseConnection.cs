using System;
using MySql.Data.MySqlClient;

namespace S25_rpg.DAL
{
    public class DatabaseConnection
    {
        public DatabaseConnection(string connectionString)
        {
            mySqlConnection = new MySqlConnection(connectionString);
        }

        internal MySqlConnection mySqlConnection { get; }
    }
}

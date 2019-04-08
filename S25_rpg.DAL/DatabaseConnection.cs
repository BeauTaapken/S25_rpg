using System;
using MySql.Data.MySqlClient;

namespace S25_rpg.DAL
{
    public class DatabaseConnection
    {
        public void setConnectionString(string connectionString)
        {
            mySqlConnection = new MySqlConnection(connectionString);
        }

        protected static MySqlConnection mySqlConnection { get; set; }
    }
}

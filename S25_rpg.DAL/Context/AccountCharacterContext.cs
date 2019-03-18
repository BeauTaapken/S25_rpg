using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.IContext;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL.Context
{
    public class AccountCharacterContext : IAccountCharacterContext
    {
        private readonly DatabaseConnection _connection;

        public AccountCharacterContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public bool AccountHasCharacter(IAccountCharacter accountCharacter)
        {
            try
            {
                int test = 0;
                _connection.mySqlConnection.Open();
                MySqlCommand accountHasCharacter =
                    new MySqlCommand("SELECT * FROM AccountCharacter WHERE Account_idAccount = @accountid", _connection.mySqlConnection);
                accountHasCharacter.Parameters.AddWithValue("@accountid", accountCharacter.Account_idAccount);
                if (int.Parse(accountHasCharacter.ExecuteScalar().ToString()) != 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                _connection.mySqlConnection.Close();
            }
        }
    }
}

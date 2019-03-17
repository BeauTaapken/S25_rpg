using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Dto;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL
{
    public class AccountContext : IAccountContext
    {
        private readonly DatabaseConnection _connection;

        public AccountContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public bool CheckAccount(IAccount account)
        {
            try
            {
                _connection.mySqlConnection.Open();

                MySqlCommand checkAccount = new MySqlCommand(
                    "SELECT * FROM Account WHERE Username = @username AND Password = @password",
                    _connection.mySqlConnection);
                checkAccount.Parameters.AddWithValue("@username", account.Username);
                checkAccount.Parameters.AddWithValue("@password", account.Password);
                if (int.Parse(checkAccount.ExecuteScalar().ToString()) == 1)
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

        public bool checkIfAccountExist(IAccount account)
        {
            try
            {
                _connection.mySqlConnection.Open();

                int test = 0;

                MySqlCommand checkIfAccountExists =
                    new MySqlCommand("SELECT * FROM Account WHERE Username = @username OR Email = @email",
                        _connection.mySqlConnection);
                checkIfAccountExists.Parameters.AddWithValue("@username", account.Username);
                checkIfAccountExists.Parameters.AddWithValue("@email", account.Email);
                //var reader = checkIfAccountExists.ExecuteReader();
                //while (reader.Read())
                //{
                //    test++;
                //}

                //if (test >= 1)
                //{
                //    _connection.mySqlConnection.Close();
                //    return true;
                //}

                if (int.Parse(checkIfAccountExists.ExecuteScalar().ToString()) == 1)
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

        public void AddAccount(IAccount account)
        {
            try
            {
                _connection.mySqlConnection.Open();
                MySqlCommand addAccount =
                    new MySqlCommand(
                        "INSERT INTO Account (Username, Password, Email) VALUES (@username, @password, @email)",
                        _connection.mySqlConnection);
                addAccount.Parameters.AddWithValue("@username", account.Username);
                addAccount.Parameters.AddWithValue("@password", account.Password);
                addAccount.Parameters.AddWithValue("@email", account.Email);
                addAccount.ExecuteNonQuery();
            }
            catch
            {
                
            }
            finally
            {
                _connection.mySqlConnection.Close();
            }
        }

        public int getAccountId(IAccount account)
        {
            try
            {
                _connection.mySqlConnection.Open();

                MySqlCommand getAccount =
                    new MySqlCommand(
                        "SELECT idAccount FROM Account WHERE Username = @username AND Password = @password",
                        _connection.mySqlConnection);

                getAccount.Parameters.AddWithValue("@username", account.Username);
                getAccount.Parameters.AddWithValue("@password", account.Password);
                var reader = getAccount.ExecuteReader();
                while (reader.Read())
                {
                    var acc = new AccountDto
                    {
                        idAccount = (int) reader["idAccount"]
                    };
                    account.idAccount = acc.idAccount;
                }
                
                return account.idAccount;
            }
            catch
            {
                return account.idAccount;
            }
            finally
            {
                _connection.mySqlConnection.Close();
            }
        }
    }
}

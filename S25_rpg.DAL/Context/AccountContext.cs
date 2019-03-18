using MySql.Data.MySqlClient;
using S25_rpg.DAL.Dto;
using S25_rpg.DAL.IContext;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL.Context
{
    public class AccountContext : IAccountContext
    {
        private readonly DatabaseConnection _connection;

        public AccountContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public bool Login(IAccount account)
        {
            try
            {
                _connection.mySqlConnection.Open();

                MySqlCommand login = new MySqlCommand(
                    "SELECT * FROM Account WHERE Username = @username AND Password = @password",
                    _connection.mySqlConnection);
                login.Parameters.AddWithValue("@username", account.Username);
                login.Parameters.AddWithValue("@password", account.Password);
                if (int.Parse(login.ExecuteScalar().ToString()) != 0)
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

        public bool CheckIfAccountExist(IAccount account)
        {
            try
            {
                _connection.mySqlConnection.Open();

                MySqlCommand checkIfAccountExists =
                    new MySqlCommand("SELECT * FROM Account WHERE Username = @username OR Email = @email",
                        _connection.mySqlConnection);
                checkIfAccountExists.Parameters.AddWithValue("@username", account.Username);
                checkIfAccountExists.Parameters.AddWithValue("@email", account.Email);

                if (int.Parse(checkIfAccountExists.ExecuteScalar().ToString()) != 0)
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

        public int GetAccountId(IAccount account)
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

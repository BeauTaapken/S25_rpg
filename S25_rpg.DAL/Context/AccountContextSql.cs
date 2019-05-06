using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class AccountContextSql : DatabaseConnection, IAccountContext
    {
        /// <summary>
        /// Function to login to an account if the user has filled in correct username and password.
        /// </summary>
        /// <param name="account"> <see cref="IAccount"></see> </param>
        /// <returns>IAccount containing account or null</returns>
        public IAccount Login(IAccount account)
        {
            IAccount a = null;
            try
            {
                mySqlConnection.Open();

                MySqlCommand login = new MySqlCommand(
                    "SELECT * FROM account WHERE Username = @username AND Password = @password",
                    mySqlConnection);
                login.Parameters.AddWithValue("@username", account.Username);
                login.Parameters.AddWithValue("@password", account.Password);
                var reader = login.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        a = new Account((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                    }
                }

                return a;
            }
            catch
            {
                return a;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            try
            {
                mySqlConnection.Open();

                MySqlCommand checkIfAccountExists =
                    new MySqlCommand("SELECT * FROM account WHERE Username = @username OR Email = @email",
                        mySqlConnection);
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
                mySqlConnection.Close();
            }
        }

        /// <summary>
        /// Function for creating an account.
        /// </summary>
        /// <param name="account"> <see cref="IAccount"></see> </param>
        public void CreateAccount(IAccount account)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand addAccount =
                    new MySqlCommand(
                        "INSERT INTO account (Username, Password, Email) VALUES (@username, @password, @email)",
                        mySqlConnection);
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
                mySqlConnection.Close();
            }
        }

        /// <summary>
        /// Function to get character from account.
        /// </summary>
        /// <param name="account"> <see cref="IAccount"></see> </param>
        /// <returns>ICharacter containing character or null</returns>
        public ICharacter AccountHasCharacter(IAccount account)
        {
            ICharacter c = null;
            int characterId = 0;
            try
            {
                mySqlConnection.Open();
                MySqlCommand accountHasCharacter =
                    new MySqlCommand("SELECT `Character_id` FROM `accountcharacter` WHERE `Account_id` = @accountid", mySqlConnection);
                accountHasCharacter.Parameters.AddWithValue("@accountid", account.idAccount);

                MySqlDataReader reader = accountHasCharacter.ExecuteReader();

                while (reader.Read())
                {
                    characterId = (int)reader[0];
                }
                reader.Close();

                if (characterId != 0)
                {
                    MySqlCommand getCharacter = new MySqlCommand("SELECT * FROM `character` WHERE `Id` = @id", mySqlConnection);
                    getCharacter.Parameters.AddWithValue("@id", characterId);

                    MySqlDataReader characterReader = getCharacter.ExecuteReader();
                    while (characterReader.Read())
                    {

                        c = new Character((int)characterReader[0], (int)characterReader[1], (int)characterReader[2], (int)characterReader[3], (int)characterReader[4], (int)characterReader[5], (Eyecolor)System.Enum.Parse(typeof(Eyecolor), characterReader[6].ToString()), (Haircolor)System.Enum.Parse(typeof(Haircolor), characterReader[7].ToString()), (int)characterReader[8], (CharacterClass)System.Enum.Parse(typeof(CharacterClass), characterReader[9].ToString()), (string)characterReader[10]);
                    }
                    characterReader.Close();
                }

                return c;
            }
            catch
            {
                return c;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}

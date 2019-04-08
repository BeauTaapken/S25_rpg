using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class CharacterContextSql : DatabaseConnection, ICharacterContext
    {
        //private readonly DatabaseConnection _connection;

        //public CharacterContextSql(DatabaseConnection connection)
        //{
        //    _connection = connection;
        //}

        //public ICharacter AccountHasCharacter(IAccount account)
        //{
        //    ICharacter c = null;
        //    try
        //    {
        //        mySqlConnection.Open();
        //        //_connection.mySqlConnection.Open();
        //        MySqlCommand accountHasCharacter =
        //            new MySqlCommand("SELECT * FROM AccountCharacter WHERE Account_idAccount = @accountid", mySqlConnection);
        //        accountHasCharacter.Parameters.AddWithValue("@accountid", account.idAccount);
        //        var reader = accountHasCharacter.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            c = new Character((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (int)reader[4], (Eyecolor)reader[5], (Haircolor)reader[6], (int)reader[7], (CharacterClass)reader[8], (string)reader[9]);
        //        }

        //        return c;
        //    }
        //    catch
        //    {
        //        return c;
        //    }
        //    finally
        //    {
        //        mySqlConnection.Close();
        //        //_connection.mySqlConnection.Close();
        //    }
        //}

        public ICharacter AddCharacter(ICharacter character, int id)
        {
            ICharacter c = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand createCharacter = new MySqlCommand(
                    "INSERT INTO `Character` (`Weight`, `Height`, `CurrentExp`, `CurrentLevel`, `Eyecolor`, `Haircolor`, `Unlockpoint_id`, `Class`, `PageUrl`) " +
                    "VALUES (@weight, @height, @currentExp, @currentLevel, @eyecolor, @haircolor, @unlockpoint, @class, @pageurl)", mySqlConnection);
                createCharacter.Parameters.AddWithValue("@weight", character.Weight);
                createCharacter.Parameters.AddWithValue("@height", character.Height);
                createCharacter.Parameters.AddWithValue("@currentExp", character.CurrentExp);
                createCharacter.Parameters.AddWithValue("@currentLevel", character.CurrentLevel);
                createCharacter.Parameters.AddWithValue("@eyecolor", character.Eyecolor.ToString());
                createCharacter.Parameters.AddWithValue("@haircolor", character.Haircolor.ToString());
                createCharacter.Parameters.AddWithValue("@unlockpoint", 1);
                createCharacter.Parameters.AddWithValue("@class", character.CharacterClass.ToString());
                createCharacter.Parameters.AddWithValue("@pageurl", "");
                createCharacter.ExecuteNonQuery();

                MySqlCommand getCharacter = new MySqlCommand("SELECT * FROM `Character` ORDER BY Id DESC LIMIT 1", mySqlConnection);
                MySqlDataReader reader = getCharacter.ExecuteReader();
                while (reader.Read())
                {
                    c = new Character((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (int)reader[4], (Eyecolor)System.Enum.Parse(typeof(Eyecolor), reader[5].ToString()), (Haircolor)System.Enum.Parse(typeof(Haircolor), reader[6].ToString()), (int)reader[7], (CharacterClass)System.Enum.Parse(typeof(CharacterClass), reader[8].ToString()), (string)reader[9]);
                }
                reader.Close();

                MySqlCommand coupleCharacterAccount = new MySqlCommand("INSERT INTO `AccountCharacter` (`Account_id`, `Character_id`) VALUES (@account, @character)", mySqlConnection);
                coupleCharacterAccount.Parameters.AddWithValue("@account", id);
                coupleCharacterAccount.Parameters.AddWithValue("@character", c.idCharacter);
                coupleCharacterAccount.ExecuteNonQuery();

                return c;
            }
            catch
            {
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}

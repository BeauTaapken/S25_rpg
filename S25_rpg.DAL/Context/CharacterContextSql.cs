
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class CharacterContextSql : DatabaseConnection, ICharacterContext
    {
        public ICharacter AddCharacter(ICharacter character, int id)
        {
            ICharacter c = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand createCharacter = new MySqlCommand(
                    "INSERT INTO `character` (`Weight`, `Height`, `CurrentExp`, `CurrentLevel`, `Eyecolor`, `Haircolor`, `QuestLevel`, `Class`, `PageUrl`) " +
                    "VALUES (@weight, @height, @currentExp, @currentLevel, @eyecolor, @haircolor, @questlevel, @class, @pageurl)", mySqlConnection);
                createCharacter.Parameters.AddWithValue("@weight", character.Weight);
                createCharacter.Parameters.AddWithValue("@height", character.Height);
                createCharacter.Parameters.AddWithValue("@currentExp", character.CurrentExp);
                createCharacter.Parameters.AddWithValue("@currentLevel", character.CurrentLevel);
                createCharacter.Parameters.AddWithValue("@eyecolor", character.Eyecolor.ToString());
                createCharacter.Parameters.AddWithValue("@haircolor", character.Haircolor.ToString());
                createCharacter.Parameters.AddWithValue("@questlevel", 1);
                createCharacter.Parameters.AddWithValue("@class", character.CharacterClass.ToString());
                createCharacter.Parameters.AddWithValue("@pageurl", "");
                createCharacter.ExecuteNonQuery();

                MySqlCommand getCharacter = new MySqlCommand("SELECT * FROM `character` ORDER BY Id DESC LIMIT 1", mySqlConnection);
                MySqlDataReader reader = getCharacter.ExecuteReader();
                while (reader.Read())
                {
                    c = new Character((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (int)reader[4], (int)reader[5], (Eyecolor)System.Enum.Parse(typeof(Eyecolor), reader[6].ToString()), (Haircolor)System.Enum.Parse(typeof(Haircolor), reader[7].ToString()), (int)reader[8], (CharacterClass)System.Enum.Parse(typeof(CharacterClass), reader[9].ToString()), (string)reader[10]);
                }
                reader.Close();

                MySqlCommand coupleCharacterAccount = new MySqlCommand("INSERT INTO `accountcharacter` (`Account_id`, `Character_id`) VALUES (@account, @character)", mySqlConnection);
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

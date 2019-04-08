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

        public ICharacter AccountHasCharacter(IAccount account)
        {
            ICharacter c = null;
            try
            {
                mySqlConnection.Open();
                //_connection.mySqlConnection.Open();
                MySqlCommand accountHasCharacter =
                    new MySqlCommand("SELECT * FROM AccountCharacter WHERE Account_idAccount = @accountid", mySqlConnection);
                accountHasCharacter.Parameters.AddWithValue("@accountid", account.idAccount);
                var reader = accountHasCharacter.ExecuteReader();
                while (reader.Read())
                {
                    c = new Character((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (int)reader[4], (Eyecolor)reader[5], (Haircolor)reader[6], (int)reader[7], (CharacterClass)reader[8], (string)reader[9]);
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
                //_connection.mySqlConnection.Close();
            }
        }

        public ICharacter AddCharacter(ICharacter character, int id)
        {
            try
            {
                mySqlConnection.Open();
                //_connection.mySqlConnection.Open();
                MySqlCommand createCharacter = new MySqlCommand(
                    "INSERT INTO Character (Weight, Height, CurrentExp, CurrentLevel, Eyecolor, Haircolor, Unlockpoint_id, Class_idClass) VALUES (@weight, @height, @currentExp, @currentLevel, @eyecolor, @haircolor, @unlockpoint, @class", mySqlConnection);
                createCharacter.Parameters.AddWithValue("@weight", character.Weight);
                createCharacter.Parameters.AddWithValue("@height", character.Height);
                createCharacter.Parameters.AddWithValue("@currentExp", character.CurrentExp);
                createCharacter.Parameters.AddWithValue("@currentLevel", character.CurrentLevel);
                createCharacter.Parameters.AddWithValue("@eyecolor", character.Eyecolor);
                createCharacter.Parameters.AddWithValue("@haircolor", character.Haircolor);
                createCharacter.Parameters.AddWithValue("@unlockpoint", character.Unlockpoint);
                createCharacter.Parameters.AddWithValue("@class", character.CharacterClass);
                createCharacter.ExecuteNonQuery();

                MySqlCommand getCharacterId = new MySqlCommand("SELECT idCharacter FROM character ORDER BY idCharacter DESC LIMIT 1", mySqlConnection);
                var reader = getCharacterId.ExecuteReader();
                while (reader.Read())
                {
                    character.idCharacter = (int)reader[0];
                }

                MySqlCommand coupleCharacterAccount = new MySqlCommand("INSERT INTO AccountCharacter (Account_idAccount, Character_idCharacter) VALUES (@account, @character)", mySqlConnection);
                coupleCharacterAccount.Parameters.AddWithValue("@account", id);
                coupleCharacterAccount.Parameters.AddWithValue("@character", character.idCharacter);
                coupleCharacterAccount.ExecuteReader();

                return character;
            }
            catch
            {
                return null;
            }
            finally
            {
                mySqlConnection.Close();
                //_connection.mySqlConnection.Close();
            }
        }
    }
}

﻿
using System.Collections.Generic;
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

        public void EditUnlockPoint(string link, ICharacter character)
        {
            throw new System.NotImplementedException();
        }

        public void EquipItem(IItem item, ICharacter character)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand equipItem = new MySqlCommand("INSERT INTO `equipped` (EquipLocation, Item_id, Character_id) VALUES (@location, @itemid, @charid) ON DUPLICATE KEY UPDATE Item_id = @itemid", mySqlConnection);
                equipItem.Parameters.AddWithValue("@location", item.Location.ToString());
                equipItem.Parameters.AddWithValue("@itemid", item.Id);
                equipItem.Parameters.AddWithValue("@charid", character.idCharacter);
                equipItem.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public IEnumerable<IEquipped> GetEquippedItems(ICharacter character)
        {
            IEnumerable<IEquipped> items = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand getEquippedItems = new MySqlCommand("SELECT equipped.Item_id, equipped.EquipLocation, item.Name FROM `equipped` INNER JOIN `item` ON equipped.Item_id = item.Id WHERE Character_id = @charid", mySqlConnection);
                getEquippedItems.Parameters.AddWithValue("@charid", character.idCharacter);
                MySqlDataReader reader = getEquippedItems.ExecuteReader();
                List<IEquipped> item = new List<IEquipped>();
                while (reader.Read())
                {
                    item.Add(new Equipped((int)reader[0], (string)reader[2], (Equiplocation)System.Enum.Parse(typeof(Equiplocation), reader[1].ToString())));
                }

                items = item;
                return items;
            }
            catch
            {
                return items;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}

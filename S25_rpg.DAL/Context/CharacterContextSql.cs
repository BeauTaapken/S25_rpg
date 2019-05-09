using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class CharacterContextSql : DatabaseConnection, ICharacterContext
    {
        /// <summary>
        /// Function for adding a character to the loged in account
        /// </summary>
        /// <param name="character"> <see cref="ICharacter"/></param>
        /// <param name="id"> <see cref="int"/></param>
        /// <returns><see cref="ICharacter"/></returns>
        public ICharacter AddCharacter(ICharacter character, IAccount account)
        {
            ICharacter c = null;
            try
            {
                mySqlConnection.Open();
                //MySqlCommand createCharacter = new MySqlCommand(
                //    "INSERT INTO `character` (`Weight`, `Height`, `CurrentExp`, `CurrentLevel`, `Eyecolor`, `Haircolor`, `QuestLevel`, `Class`, `PageUrl`) VALUES (@weight, @height, @currentExp, @currentLevel, @eyecolor, @haircolor, @questlevel, @class, @pageurl)", mySqlConnection);
                MySqlCommand createCharacter = new MySqlCommand("AddCharacter", mySqlConnection);
                createCharacter.CommandType = CommandType.StoredProcedure;
                createCharacter.Parameters.AddWithValue("iWeight", character.Weight);
                createCharacter.Parameters.AddWithValue("iHeight", character.Height);
                createCharacter.Parameters.AddWithValue("iCurrentExp", character.CurrentExp);
                createCharacter.Parameters.AddWithValue("iCurrentLvl", character.CurrentLevel);
                createCharacter.Parameters.AddWithValue("eEyecolor", character.Eyecolor.ToString());
                createCharacter.Parameters.AddWithValue("eHaircolor", character.Haircolor.ToString());
                createCharacter.Parameters.AddWithValue("iQuestLvl", 1);
                createCharacter.Parameters.AddWithValue("eClass", character.CharacterClass.ToString());
                createCharacter.Parameters.AddWithValue("sPageurl", "");
                createCharacter.Parameters.Add("iCharId", MySqlDbType.Int32);
                createCharacter.Parameters["iCharId"].Direction = ParameterDirection.Output;
                createCharacter.ExecuteNonQuery();

                int charId = Convert.ToInt32(createCharacter.Parameters["iCharId"].Value);

                MySqlCommand getCharacter = new MySqlCommand("SELECT * FROM `character` WHERE Id = @charid", mySqlConnection);
                getCharacter.Parameters.AddWithValue("@charid", charId);
                MySqlDataReader reader = getCharacter.ExecuteReader();
                while (reader.Read())
                {
                    c = new Character((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (int)reader[4], (int)reader[5], (Eyecolor)System.Enum.Parse(typeof(Eyecolor), reader[6].ToString()), (Haircolor)System.Enum.Parse(typeof(Haircolor), reader[7].ToString()), (int)reader[8], (CharacterClass)System.Enum.Parse(typeof(CharacterClass), reader[9].ToString()), (string)reader[10]);
                }
                reader.Close();

                MySqlCommand coupleCharacterAccount = new MySqlCommand("INSERT INTO `accountcharacter` (`Account_id`, `Character_id`) VALUES (@account, @character)", mySqlConnection);
                coupleCharacterAccount.Parameters.AddWithValue("@account", account.idAccount);
                coupleCharacterAccount.Parameters.AddWithValue("@character", c.idCharacter);
                coupleCharacterAccount.ExecuteNonQuery();

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

        /// <summary>
        /// Function to edit the ammount of gold a character is holding
        /// </summary>
        /// <param name="gold"><see cref="int"/></param>
        /// <param name="character"><see cref="ICharacter"/></param>
        public void EditGold(int gold, ICharacter character)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand editGold = new MySqlCommand("UPDATE `character` SET Gold = Gold + @gold WHERE Id = @charid", mySqlConnection);
                editGold.Parameters.AddWithValue("@gold", gold);
                editGold.Parameters.AddWithValue("@charid", character.idCharacter);
                editGold.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();;
            }
        }


        /// <summary>
        /// Function for editing the exp and level of a character
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <param name="gottenExp"><see cref="int"/></param>
        public void EditExpAndLevel(ICharacter character, int gottenExp)
        {
            try
            {
                mySqlConnection.Open();
                int exp = 0;
                int lvl = 0;
                MySqlCommand getExpAndLevel = new MySqlCommand("SELECT CurrentExp, CurrentLevel FROM `character` WHERE Id = @id", mySqlConnection);
                getExpAndLevel.Parameters.AddWithValue("@id", character.idCharacter);
                MySqlDataReader reader = getExpAndLevel.ExecuteReader();
                while (reader.Read())
                {
                    exp = (int) reader[0];
                    lvl = (int) reader[1];
                }
                reader.Close();
                int neededExp = lvl * 100;
                if (exp + gottenExp >= neededExp)
                {
                    MySqlCommand editLvl = new MySqlCommand("UPDATE `character` SET CurrentLevel = CurrentLevel + 1 WHERE Id = @id", mySqlConnection);
                    editLvl.Parameters.AddWithValue("@id", character.idCharacter);
                    editLvl.ExecuteNonQuery();
                    exp = (exp + gottenExp) - neededExp;
                }
                else
                {
                    exp += gottenExp;
                }
                MySqlCommand editExp = new MySqlCommand("UPDATE `character` SET CurrentExp = @exp WHERE Id = @id", mySqlConnection);
                editExp.Parameters.AddWithValue("@exp", exp);
                editExp.Parameters.AddWithValue("@id", character.idCharacter);
                editExp.ExecuteNonQuery();
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
        /// Function for equiping an item to a character
        /// </summary>
        /// <param name="item"><see cref="IItem"/></param>
        /// <param name="character"><see cref="ICharacter"/></param>
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

        /// <summary>
        /// Function for dequiping an item from a character
        /// </summary>
        /// <param name="item"><see cref="IItem"/></param>
        /// <param name="character"><see cref="ICharacter"/></param>
        public void DequipItem(IItem item, ICharacter character)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand dequipItem = new MySqlCommand("DELETE FROM `equipped` WHERE Item_id = @itemid AND Character_id = @charid", mySqlConnection);
                dequipItem.Parameters.AddWithValue("@itemid", item.Id);
                dequipItem.Parameters.AddWithValue("@charid", character.idCharacter);
                dequipItem.ExecuteNonQuery();
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
        /// Function for getting all the equipped items of a character
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <returns><see cref="ICharacter"/></returns>
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

        public void EditStartLink(string link, ICharacter character)
        {

        }
    }
}

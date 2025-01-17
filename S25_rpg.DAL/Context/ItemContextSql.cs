﻿using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Item;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class ItemContextSql : DatabaseConnection, IItemContext
    {
        /// <summary>
        /// Function for getting all a characters items.
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <returns><see cref="IEnumerable{IItem}"/></returns>
        public IEnumerable<Item> GetAllCharacterItems(Character character)
        {
            try
            {
                mySqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT `characteritem`.Ammount, `item`.* FROM `characteritem` INNER JOIN `item` ON `characteritem`.Item_id = `item`.Id WHERE `characteritem`.Character_id = @charid", mySqlConnection);
                cmd.Parameters.AddWithValue("@charid", character.idCharacter);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Item> item = new List<Item>();
                while (reader.Read())
                {
                    item.Add(new Item((int) reader[1], (int) reader[0], (string) reader[2], (string) reader[3], (int) reader[4], (bool) reader[5], reader[6].Equals(DBNull.Value) ? 0 : (int) reader[6], reader[7].Equals(DBNull.Value) ? 0 : (int)reader[7], reader[8].Equals(DBNull.Value) ? null : (Equiplocation?)System.Enum.Parse(typeof(Equiplocation), reader[8].ToString())));
                }

                IEnumerable<Item> items = item;

                return items;
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

        /// <summary>
        /// Function for adding an item to a characters inventory
        /// </summary>
        /// <param name="item"><see cref="IItem"/></param>
        /// <param name="character"><see cref="ICharacter"/></param>
        public void AddItem(Item item, Character character)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand AddQuestItems =
                    new MySqlCommand(
                        "INSERT INTO `characteritem` (Character_id, Item_id, Ammount) VALUES (@charid, @itemid, @gottenItems) ON DUPLICATE KEY UPDATE Ammount = Ammount + @gottenItems",
                        mySqlConnection);
                AddQuestItems.Parameters.AddWithValue("@charid", character.idCharacter);
                AddQuestItems.Parameters.AddWithValue("@itemid", item.Id);
                AddQuestItems.Parameters.AddWithValue("@gottenItems", item.Ammount);
                AddQuestItems.ExecuteNonQuery();
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
        /// Function for removing an item from a characters inventory
        /// </summary>
        /// <param name="item"><see cref="IItem"/></param>
        /// <param name="character"><see cref="ICharacter"/></param>
        public void RemoveItem(Item item, Character character)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand RemoveQuestItems =
                    new MySqlCommand(
                        "UPDATE characteritem SET Ammount = Ammount - @gottenAmmount WHERE Item_id = @itemid && Character_id = @charid",
                        mySqlConnection);
                RemoveQuestItems.Parameters.AddWithValue("@gottenammount", item.Ammount);
                RemoveQuestItems.Parameters.AddWithValue("@itemid", item.Id);
                RemoveQuestItems.Parameters.AddWithValue("@charid", character.idCharacter);
                RemoveQuestItems.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}

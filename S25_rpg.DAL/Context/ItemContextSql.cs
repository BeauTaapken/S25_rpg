using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Interface.Item;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class ItemContextSql : DatabaseConnection, IItemContext
    {
        public IEnumerable<IItem> GetAllCharacterItems(ICharacter character)
        {
            try
            {
                mySqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT `characteritem`.Ammount, `item`.* FROM `characteritem` INNER JOIN `item` ON `characteritem`.Item_id = `item`.Id WHERE `characteritem`.Character_id = 32", mySqlConnection);
                cmd.Parameters.AddWithValue("@charid", character.idCharacter);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<IItem> item = new List<IItem>();
                while (reader.Read())
                {
                    item.Add(new Item((int) reader[1], (int) reader[0], (string) reader[2], (string) reader[3], (int) reader[4], (bool) reader[5], reader[6].Equals(DBNull.Value) ? 0 : (int) reader[6], reader[7].Equals(DBNull.Value) ? 0 : (int)reader[7], reader[8].Equals(DBNull.Value) ? null : (Equiplocation?)System.Enum.Parse(typeof(Equiplocation), reader[8].ToString())));
                }

                IEnumerable<IItem> items = item;

                return items;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public void AddItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IItem> GetAllShopItems(string shopName)
        {
            throw new NotImplementedException();
        }
    }
}

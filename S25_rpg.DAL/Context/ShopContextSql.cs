using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Interface.Shop;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class ShopContextSql : DatabaseConnection, IShopContext
    {
        /// <summary>
        /// Function to get all items from the shop out of the database
        /// </summary>
        /// <returns><see cref="IShop"/></returns>
        public IShop GetAllShopItems()
        {
            Shop shop = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand getShopItems =
                    new MySqlCommand(
                        "SELECT `itemshop`.`BuyPrice`, `shop`.Name, `item`.* FROM `itemshop` INNER JOIN `shop` ON `itemshop`.Shop_id = `shop`.`Id` INNER JOIN `item` ON `item`.Id = `itemshop`.`Item_id` WHERE `shop`.Id = 1",
                        mySqlConnection);
                MySqlDataReader reader = getShopItems.ExecuteReader();
                List<IItem> items = new List<IItem>();
                string shopName = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(new Item((int)reader[2], (string)reader[3], (string)reader[4], (int)reader[0], (int)reader[5]));
                        shopName = (string)reader[1];
                    }
                }
                shop = new Shop(shopName, items);
                return shop;
            }
            catch
            {
                return shop;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}

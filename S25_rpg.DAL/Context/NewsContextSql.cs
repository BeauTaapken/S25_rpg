using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Interface.News;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class NewsContextSql : DatabaseConnection, INewsContext
    {
        public List<INews> GetAllNews()
        {
            List<INews> news = new List<INews>();
            try
            {
                mySqlConnection.Open();
                MySqlCommand getNews = new MySqlCommand("SELECT * FROM news ORDER BY Id DESC", mySqlConnection);
                MySqlDataReader reader = getNews.ExecuteReader();
                while (reader.Read())
                {
                    news.Add(new News((int)reader[0], (string)reader[1], (string)reader[2]));
                }
                reader.Close();
                return news;
            }
            catch(Exception ex)
            {
                return news;
            }
            finally
            {
                mySqlConnection.Close();
            }
            
        }
    }
}

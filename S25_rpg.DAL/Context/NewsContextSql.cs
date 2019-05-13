using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.News;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class NewsContextSql : DatabaseConnection, INewsContext
    {
        /// <summary>
        /// Function for getting all the news from the database
        /// </summary>
        /// <returns><see cref="List{INews}"/></returns>
        public List<News> GetAllNews()
        {
            List<News> news = new List<News>();
            try
            {
                mySqlConnection.Open();
                //MySqlCommand getNews = new MySqlCommand("SELECT * FROM news ORDER BY Id DESC", mySqlConnection);
                MySqlCommand getNews = new MySqlCommand("GetNews", mySqlConnection);
                MySqlDataReader reader = getNews.ExecuteReader();
                while (reader.Read())
                {
                    news.Add(new News((int)reader[0], (string)reader[1], (string)reader[2]));
                }
                reader.Close();
                return news;
            }
            catch
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

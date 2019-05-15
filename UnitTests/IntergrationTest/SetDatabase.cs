using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL;

namespace Tests.IntergrationTest
{
    public class SetDatabase
    {
        public SetDatabase()
        {
            DatabaseConnection db = new DatabaseConnection();
            db.setConnectionString("server=localhost;database=rpg;uid=root;password=");
        }
    }
}

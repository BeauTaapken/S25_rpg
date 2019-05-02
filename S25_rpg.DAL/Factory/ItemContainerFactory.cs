using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Item;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class ItemContainerFactory
    {
        public static IItemContainerRepo ItemContainerRepo = new ItemRepository(new ItemContextSql());
    }
}

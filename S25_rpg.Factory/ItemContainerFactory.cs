using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Item;

namespace S25_rpg.Factory
{
    public static class ItemContainerFactory
    {
        public static IItemContainerRepo MySqlItemContainerRepo()
        {
            return new ItemRepository(new ItemContextSql());
        }

        public static IItemContainerRepo MemoryItemContainerRepo()
        {
            return new ItemRepository();
        }
    }
}

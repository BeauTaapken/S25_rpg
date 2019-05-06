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
        public static IItemContainerRepo ItemContainerRepo()
        {
            return new ItemRepository(new ItemContextSql());
        } 
    }
}

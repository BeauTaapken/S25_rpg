using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.IContext;

namespace S25_rpg.DAL.Interface.Account
{
    public interface IAccountContext : IAccountCollectionRepo, IAccountRepo
    {
    }
}

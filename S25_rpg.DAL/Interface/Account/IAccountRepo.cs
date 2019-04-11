
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface.Account
{
    public interface IAccountRepo
    {
        void Logout();

        ICharacter AccountHasCharacter(IAccount account);
    }
}

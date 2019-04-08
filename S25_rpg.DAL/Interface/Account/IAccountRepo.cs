
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.IContext
{
    public interface IAccountRepo
    {
        void Logout();

        ICharacter AccountHasCharacter(IAccount account);
    }
}


using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Account
{
    public interface IAccountRepo
    {
        void Logout();

        ICharacter AccountHasCharacter(IAccount account);
    }
}

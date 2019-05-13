using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Interfaces.Account
{
    public interface IAccountRepo
    {
        void Logout();

        Models.Character AccountHasCharacter(Models.Account account);
    }
}

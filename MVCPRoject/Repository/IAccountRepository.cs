using MVCPRoject.Models;

namespace MVCPRoject.Repository
{
    public interface IAccountRepository:IRepository<UserAccount>
    {
        UserAccount FindAccount(string username, string password);
    }
}

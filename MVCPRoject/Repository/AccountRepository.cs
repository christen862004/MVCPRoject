using MVCPRoject.Models;

namespace MVCPRoject.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public string ID { get; set; }
        CompanyContext Context;
        public AccountRepository(CompanyContext _context)
        {
            Context = _context;
        }

        public UserAccount FindAccount(string username, string password)
        {
            UserAccount user= Context.UserAccounts.FirstOrDefault(a=>a.UserName==username &&  a.Password==password);
            return user;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserAccount GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserAccount obj)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserAccount obj)
        {
            throw new NotImplementedException();
        }
    }
}

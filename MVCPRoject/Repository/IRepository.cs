using MVCPRoject.Models;

namespace MVCPRoject.Repository
{
    public interface IRepository<T>
    {
        string ID { get; set; }

        List<T> GetAll();

        T GetByID(int id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        int Save();
        
    }
}
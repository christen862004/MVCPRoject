using MVCPRoject.Models;

namespace MVCPRoject.Repository
{
    public class EmployeeRepository:IRepository<Employee>
    {
        CompanyContext Context;
        
        public string ID { get; set; }

        public EmployeeRepository(CompanyContext _context)//inject 
        {
            Context = _context;
        }
        //CRUD
        public List<Employee> GetAll()
        {
            return Context.Employees.ToList();//lazy Loading
        }

        public Employee GetByID(int id)
        {
            return Context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(Employee obj)
        {
            Context.Add(obj);//memory  
        }

        public void Update(Employee obj)
        {
            Context.Update(obj);
        }

        public void Delete(int id)
        {
            Employee emp = GetByID(id);
            Context.Remove(emp);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}

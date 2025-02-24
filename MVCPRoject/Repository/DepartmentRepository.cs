using Microsoft.EntityFrameworkCore;
using MVCPRoject.Models;

namespace MVCPRoject.Repository
{
    public class DepartmentRepository: IRepository<Department>
    {
        CompanyContext Context;
        public string ID { get; set; }


        public DepartmentRepository(CompanyContext Ctx)
        {
            ID = Guid.NewGuid().ToString();
            Context = Ctx;
        }
        //CRUD
        public List<Department> GetAll()
        {
            return Context.Departments.Include(e=>e.Employees).ToList();//lazy Loading
        }
            
        public Department GetByID(int id) {
            return Context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department obj)
        {
            Context.Add(obj);//memory  
        }

        public void Update(Department obj)
        {
            Context.Update(obj);
        }

        public void Delete(int id)
        {
            Department dept = GetByID(id);
            Context.Remove(dept);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}

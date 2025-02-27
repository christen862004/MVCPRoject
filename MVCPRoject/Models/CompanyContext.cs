using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace MVCPRoject.Models
{
    //soft Delete(update)
    //Databse
    public class CompanyContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public CompanyContext():base()
        {      
        }
        //constructor that used by IOC Container
        public CompanyContext(DbContextOptions<CompanyContext> option):base(option)//ioc container
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WinterCamp;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

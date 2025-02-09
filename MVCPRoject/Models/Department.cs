using System.ComponentModel.DataAnnotations;

namespace MVCPRoject.Models
{
    public class Department
    {
        public int Id { get; set; }//Pk ,identity=1 increment by 1

        public string Name { get; set; }//Not Allow Null

        public string? ManagerName { get; set; }//Allow Null

        public List<Employee>? Employees { get; set; }
    }
}

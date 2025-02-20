using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPRoject.Models
{
    public class Employee
    {
        public int Id { get; set; }//PK
        public string  Name { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? Jobtitle { get; set; }
        
        [ForeignKey("Department")]
        [Display(Name="Department Name")]
        public int DepartmentID { get; set; }//contarint Foriegn Key

        public Department? Department { get; set; }//navigation property not convert to column

    }
}

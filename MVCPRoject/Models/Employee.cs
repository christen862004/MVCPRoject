using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPRoject.Models
{
    public class Employee
    {
        public int Id { get; set; }//PK

        [Required]//not allow null (by default attribute)
        [MaxLength(20,ErrorMessage ="Name Must be less than 20 char")]//default message error
        [MinLength(3,ErrorMessage ="Name Must be More Than 3 char")]
        [Unique]//server side Only
        public string  Name { get; set; }

        [Range(7000,50000)]
        [Remote("CheckSalary","Employee",ErrorMessage ="Salary Must % 3",AdditionalFields = "Address")]
        public int Salary { get; set; }
        

        public string? Address { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]
        public string? ImageURL { get; set; }

        public string? Jobtitle { get; set; }
        
        [ForeignKey("Department")]
        [Display(Name="Department Name")]
        public int DepartmentID { get; set; }//contarint Foriegn Key

       // [Required]
        public Department? Department { get; set; }//navigation property not convert to column

    }
}

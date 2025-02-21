using System.ComponentModel.DataAnnotations;

namespace MVCPRoject.Models
{
    public class UniqueAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            Employee EmpFromReuest = (Employee)validationContext.ObjectInstance;

            
            CompanyContext context = new CompanyContext();
            
            Employee EmpFromDataBase=
                context.Employees.FirstOrDefault(e=>e.Name == name && e.DepartmentID== EmpFromReuest.DepartmentID);

            if(EmpFromDataBase == null) {
                return ValidationResult.Success;
            }

            return new ValidationResult("Name Already Found !!!");
        }
    }
}

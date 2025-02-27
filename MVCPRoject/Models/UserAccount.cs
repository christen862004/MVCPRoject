using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPRoject.Models
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

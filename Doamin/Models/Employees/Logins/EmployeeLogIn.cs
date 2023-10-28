using Domain.Models.CommonEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Employees.Logins;

public class EmployeeLogIn : CommanEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string Code { get; set; }
    public string Password { get; set; }
}

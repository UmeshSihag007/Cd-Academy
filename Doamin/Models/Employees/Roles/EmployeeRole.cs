using System.ComponentModel.DataAnnotations;
namespace Domain.Models.Employees.Roles;
public class EmployeeRole
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

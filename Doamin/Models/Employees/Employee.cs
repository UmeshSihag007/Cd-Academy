using Domain.Models.CommonEntities;
using Domain.Models.Employees.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Employees;

public class Employee : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string EmailId { get; set; }
    public string? Gender { get; set; }
    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public Employee Parent { get; set; }

    [ForeignKey("EmployeeRole")]
    public int RoleId { get; set; }
    public EmployeeRole EmployeeRole { get; set; }
}

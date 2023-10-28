using Domain.Models.CommonEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Employees.Devices;

public class EmployeeDevice : CommanEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string? SerialNumber { get; set; }
    public string? DeviceId { get; set; }
    public string? MainNumber { get; set; }


}

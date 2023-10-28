using Domain.Models.CommonEntities;
using Domain.Models.Employees.Addresses.Types;
using Domain.Models.Employees.Locations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Employees.Addresses;

public class EmployeeAddress : CommanEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    [ForeignKey("AddressType")]
    public int AddressTypeId { get; set; }
    public AddressType AddressType { get; set; }
    [ForeignKey("Location")]
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public string? street_1 { get; set; }
    public string?   street_2 { get; set; }
    public int? PinCode { get; set; }
    public long MobileNumber { get; set; }
    public string EmailId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Employees.Addresses.Types;

public class AddressType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

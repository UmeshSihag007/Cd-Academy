using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Employees.Locations;

public class Location
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public Location Parent { get; set; }
    public bool? IsActive { get; set; }
}

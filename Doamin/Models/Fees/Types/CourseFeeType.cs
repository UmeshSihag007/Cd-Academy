using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Fees.Types;

public class CourseFeeType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

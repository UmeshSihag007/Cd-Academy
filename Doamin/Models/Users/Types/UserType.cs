using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users.Types;

public class UserType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }

}

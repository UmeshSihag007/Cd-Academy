using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Menus.Types;

public class MenuType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}

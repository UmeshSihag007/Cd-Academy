using Domain.Models.CommonEntities;
using Domain.Models.Menus.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Menus;

public class Menu : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string NavigateUrl { get; set; }
    public string? Icon { get; set; }
    [ForeignKey("ParentId")]
    public int? ParentId { get; set; }
    public Menu? Parent { get; set; }
    [ForeignKey("MenuType")]
    public int TypeId { get; set; }
    public MenuType MenuType { get; set; }
    public bool IsNew { get; set; }
    public List<Menu> Children { get; set; }
}

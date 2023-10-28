using Domain.Models.CommonEntities;
using Domain.Models.Menus;

namespace Application.Contracts.Menus;

public class MenuDto : CommanEntity
{
    public int Id {get; set; }
    public string Name { get; set; }
    public string NavigateUrl { get; set; }
    public string Icon { get; set; }
    public int ParentId { get; set; }
    public int TypeId { get; set; }
    public bool IsNew { get; set; }
    public List<MenuDto> Children { get; set; }
}

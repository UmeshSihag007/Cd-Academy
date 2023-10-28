namespace Application.Contracts.Menus;

public class CreateMenuDto
{
    public string Name { get; set; }
    public string NavigateUrl { get; set; }
    public string Icon { get; set; }
    public int? ParentId { get; set; }
    public int TypeId { get; set; }
    public bool IsNew { get; set; }
}

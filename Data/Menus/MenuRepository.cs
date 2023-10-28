using Data.Comman;
using Domain.Models.Menus;
using Microsoft.EntityFrameworkCore;

namespace Data.Menus;

public class MenuRepository : EFRepository<Menu>, IMenuRepository
{
    private readonly DataContext _dataContext;
    public MenuRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Menu>> GetbyParentId(int id)
    {
        var data = await (from menu in _dataContext.Menus
                          join menutype in _dataContext.MenuTypes on menu.TypeId equals menutype.Id
                          where menu.ParentId == id
                          select new Menu()
                          {
                              Id = menu.Id,
                              Name = menu.Name,
                              NavigateUrl = menu.NavigateUrl,
                              Icon = menu.Icon,
                              ParentId = menu.ParentId,
                              TypeId = menu.TypeId,
                              IsNew = menu.IsNew,
                              IsActive = menu.IsActive,

                          }).ToListAsync();
        return data;
    }

    public async Task<List<Menu>> GetList()
    {
        var data = await _dataContext.Menus
             .Where(x => x.IsDeleted == false)
    .Include(x => x.Children)
    .ToListAsync();
        return data;
    }

    public async Task<List<Menu>> GetbyTypeId(int id)
    {
        var data = await (from menu in _dataContext.Menus
                          join menutype in _dataContext.MenuTypes on menu.TypeId equals menutype.Id
                          where menu.TypeId == menutype.Id && menu.TypeId == id 
                          select new Menu()
                          {
                              Id = menu.Id,
                              Name = menu.Name,
                              NavigateUrl = menu.NavigateUrl,
                              Icon = menu.Icon,
                              ParentId = menu.ParentId,
                              TypeId = menu.TypeId,
                              IsNew = menu.IsNew,
                              IsActive = menu.IsActive,
                              Children = menu.Children.Where(menu => menu.ParentId == menu.Id)
                                    .Select(x => new Menu()
                                    {
                                        Id = menu.Id,
                                        Name = menu.Name,
                                        NavigateUrl = menu.NavigateUrl,
                                        Icon = menu.Icon,
                                        ParentId = menu.ParentId,
                                        TypeId = menu.TypeId,
                                        IsNew = menu.IsNew,
                                        IsActive = menu.IsActive,
                                    }).ToList(),
                          }).ToListAsync();
      return data;
    }
}

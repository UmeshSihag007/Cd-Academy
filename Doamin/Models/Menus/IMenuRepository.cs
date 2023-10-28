using Domain.Models.Comman;

namespace Domain.Models.Menus;

public interface IMenuRepository : IRepository<Menu>
{
    Task<List<Menu>> GetbyTypeId(int id);
    Task<List<Menu>> GetbyParentId(int id);
    Task<List<Menu>> GetList();
}

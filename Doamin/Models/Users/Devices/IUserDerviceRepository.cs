using Domain.Models.Comman;

namespace Domain.Models.Users.Devices;
public interface IUserDerviceRepository : IRepository<UserDevice>
{
    Task<UserDevice> GetbyUserDeviceId(int userId);
}

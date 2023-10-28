using Data.Comman;
using Domain.Models.Users.Devices;
using Microsoft.EntityFrameworkCore;

namespace Data.Users.Dervices;

public class UserDerviceRepository : EFRepository<UserDevice>, IUserDerviceRepository
{
    private readonly DataContext _context;
    public UserDerviceRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }
    public async Task<UserDevice> GetbyUserDeviceId(int userId)
    {
        var userdevice = await _context.UserDevices
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();

        return userdevice;
    }
}

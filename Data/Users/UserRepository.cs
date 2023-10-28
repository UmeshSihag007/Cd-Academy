using Data.Comman;
using Domain.Models.Users;
using Domain.Models.Users.Logins;
using Microsoft.EntityFrameworkCore;

namespace Data.Users;

public class UserRepository : EFRepository<User>, IUserRepository
{
    private readonly DataContext _dataContext;
    public UserRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<UserLogin> GetUserByCodeAndPassword(string code, string password)
    {
        var user = await _dataContext.UserLogins.FirstOrDefaultAsync(x => x.Code == code && x.Password == password);
        return user;
    }

    public async Task<UserDetails> GetById(int id)
    {
        var data = await (from user in _dataContext.Users
                          join userlog in _dataContext.UserLogins on user.Id equals userlog.UserId into userLogGroup
                          from userlog in userLogGroup.DefaultIfEmpty()
                          join userdevice in _dataContext.UserDevices on user.Id equals userdevice.UserId into userDeviceGroup
                          from userdevice in userDeviceGroup.DefaultIfEmpty()
                          where user.Id == id
                          select new UserDetails()
                          {
                              Id = user.Id,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              MobileNumber = user.MobileNumber,
                              IsMobileConfirmed = user.IsMobileConfirmed,
                              EmailId = user.EmailId,
                              IsEmailConfirmed = user.IsEmailConfirmed,
                              DOB = user.DOB,
                              LocationId = user.LocationId ?? default(int),
                              Address = user.Address,
                              PinCode = user.PinCode,
                              ParentId = user.ParentId != null ? user.ParentId : (int?)null,
                              ProfileImageUrlId = user.ProfileImageUrlId ?? default(int),
                              Typeid = user.UserTypeId ?? default(int),
                              Code = userlog.Code,
                              Password = userlog.Password,
                              SerialNumber = userdevice.SerialNumber,
                              DeviceId = userdevice.DeviceId,
                              MainNumber = userdevice.MainNumber,
                          }).FirstOrDefaultAsync();
        return data;
    }
    public async Task<List<UserDetails>> GetList()
    {
        var data = await (from user in _dataContext.Users
                          join userlog in _dataContext.UserLogins on user.Id equals userlog.UserId into userLogGroup
                          from userlog in userLogGroup.DefaultIfEmpty()
                          join userdevice in _dataContext.UserDevices on user.Id equals userdevice.UserId into userDeviceGroup
                          from userdevice in userDeviceGroup.DefaultIfEmpty()
                          select new UserDetails()
                          {
                              Id = user.Id,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              MobileNumber = user.MobileNumber,
                              IsMobileConfirmed = user.IsMobileConfirmed,
                              EmailId = user.EmailId,
                              IsEmailConfirmed = user.IsEmailConfirmed,
                              DOB = user.DOB,
                              LocationId = user.LocationId ?? default(int),
                              Address = user.Address,
                              PinCode = user.PinCode,
                              ParentId = user.ParentId != null ? user.ParentId : (int?)null,
                              ProfileImageUrlId = user.ProfileImageUrlId ?? default(int),
                              Typeid = user.UserTypeId ?? default(int),
                              Code = userlog.Code,
                              Password = userlog.Password,
                              SerialNumber = userdevice.SerialNumber,
                              DeviceId = userdevice.DeviceId,
                              MainNumber = userdevice.MainNumber,

                          }).ToListAsync();
        return data;
    }

    public async Task<LoginToken> GetUserLoginById(int? id)
    {
        var output = await (from userlog in _dataContext.UserLogins
                            join user in _dataContext.Users on userlog.UserId equals user.Id
                            join usertype in _dataContext.UserTypes on user.UserTypeId equals usertype.Id
                            where user.Id == id
                            select new LoginToken
                            {
                                Code = userlog.Code,
                                Password = userlog.Password,
                                Role = usertype.Name,
                            }).FirstOrDefaultAsync();
        return output;
    }

    public async Task<bool> CheckEmailInExists(string email)
    {
        var checkEmailInExists= await _dataContext.Users.AnyAsync(x=>x.EmailId== email);
        if (checkEmailInExists)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(u => u.EmailId == email);
    }

}

using Data.Comman;
using Domain.Models.Users;
using Domain.Models.Users.Logins;
using Microsoft.EntityFrameworkCore;

namespace Data.Users.Logins;

public class UserLoginRepository : EFRepository<UserLogin>, IUserLoginRepository
{
    private readonly DataContext _dataContext;
    public UserLoginRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserLogin> GetByUserPassword(string password)
    {
        var userlogin = await _dataContext.UserLogins
        .Where(x => x.Password == password)
        .FirstOrDefaultAsync();
        return userlogin;
    }

    public async Task<UserLogin> GetLoginByUserId(int userId)
    {
        var userlogin = await _dataContext.UserLogins
        .Where(x => x.UserId == userId)
        .FirstOrDefaultAsync();
        return userlogin;
    }
}

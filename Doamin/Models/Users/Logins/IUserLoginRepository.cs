using Domain.Models.Comman;

namespace Domain.Models.Users.Logins;

public interface IUserLoginRepository : IRepository<UserLogin>
{
    Task<UserLogin> GetLoginByUserId(int userId);
    Task<UserLogin> GetByUserPassword(string password);

}

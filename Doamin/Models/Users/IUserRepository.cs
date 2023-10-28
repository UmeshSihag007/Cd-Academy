using Domain.Models.Comman;
using Domain.Models.Users.Logins;

namespace Domain.Models.Users;

public interface IUserRepository : IRepository<User>
{
    Task<UserLogin> GetUserByCodeAndPassword(string code, string password);
    Task<LoginToken> GetUserLoginById(int? id);
    Task<UserDetails> GetById(int id);
    Task<List<UserDetails>> GetList();
    Task<bool> CheckEmailInExists(string email);

    Task<User> GetUserByEmail(string email);


}

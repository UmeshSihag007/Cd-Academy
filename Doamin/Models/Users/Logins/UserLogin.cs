using Domain.Models.CommonEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users.Logins;

public class UserLogin : CommanEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
    public string Password { get; set; }
    public string Code { get; set; }
    public UserLogin() { }
    public UserLogin(int userId, string code, string password) 
    { UserId = userId; Code = code; Password = password; }
}

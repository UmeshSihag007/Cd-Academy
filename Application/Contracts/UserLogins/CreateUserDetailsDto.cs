namespace Application.Contracts.UserLogins;

public class CreateUserDetailsDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long MobileNumber { get; set; }
    public string EmailId { get; set; }
    public string Password { get; set; }
}

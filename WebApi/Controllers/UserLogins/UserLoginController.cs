using Application.Contracts.UserLogins;
using AutoMapper;
using Data;
using Domain.Models.Users;
using Domain.Models.Users.Devices;
using Domain.Models.Users.Logins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers.UserLogins;


[ApiController]
public class UserLoginController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserLoginRepository _userLoginRepository;
    private readonly IUserDerviceRepository _userDerviceRepository;

    public UserLoginController(DataContext dataContext, IMapper mapper, IUserRepository userRepository, IUserLoginRepository userLoginRepository, IUserDerviceRepository userDerviceRepository)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _userRepository = userRepository;
        _userLoginRepository = userLoginRepository;
        _userDerviceRepository = userDerviceRepository;
    }

    [HttpPost]
    [Route("api/userlogin")]
    public async Task<ActionResult<string>> Login(UserLoginVerfiyDto command)
    {
        var user = await _userRepository.GetUserByCodeAndPassword(command.Code, command.Password);

        if (user == null)
        {
            return Unauthorized("Please provide the correct code and password");
        }

        var role = await _userRepository.GetUserLoginById(user.UserId);
        var claims = new List<Claim>
            {
             new Claim("Password", user.Password),
             new Claim("Code", user.Code),
             new Claim("Id", user.Id.ToString()),
             new Claim("Role",role.Role),
        };

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:5001",
            audience: "https://localhost:5001",
            claims: claims,
            expires: DateTime.Now.AddDays(2),
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return Ok(new AuthenticatedResponse { Token = tokenString });
    }

    [HttpPost]
    [Route("api/forget-password")]
    public async Task<ActionResult<string>> ForgetPassword(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest("Please provide a valid email.");
        }

        var emailExists = await _userRepository.CheckEmailInExists(email);

        if (!emailExists)
        {
            return BadRequest("Email not found in the database.");
        }

        User user = await _userRepository.GetUserByEmail(email);

        if (user == null)
        {
            return BadRequest("User not found in the database.");
        }

        UserLogin userLogin = await _userLoginRepository.GetLoginByUserId(user.Id);
        string recipientEmail = user.EmailId;
        string username = user.FirstName + " " + user.LastName;
        string code = userLogin.Code;
        string password = userLogin.Password;

        if (string.IsNullOrWhiteSpace(recipientEmail))
        {
            return BadRequest("User's email address is missing.");
        }

        string subject = "Your Code and Password";

        string wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string htmlTemplatePath = Path.Combine(wwwrootPath, "mails/restpasswordmail.html");
        string htmlTemplate = System.IO.File.ReadAllText(htmlTemplatePath);

        string emailBody = htmlTemplate.Replace("{{user_name}}", username)
                                       .Replace("{{username}}", username)
                                       .Replace("{{reset_code}}", code)
                                       .Replace("{{old_password}}", password)
                                       .Replace("{{email}}", email);

        EmailService emailService = new EmailService();
        emailService.SendEmail(recipientEmail, subject, emailBody);
        return Ok("Email sent successfully");
    }

    [HttpPost]
    [Route("api/change-password")]
    public async Task<ActionResult> ChangePassword(ChangePasswordDto input)
    {
        var userLogin = await _userLoginRepository.GetByUserPassword(input.OldPassWord);
        if (userLogin == null)
        {
            return NotFound("Invalid User.......");
        }
        if (userLogin.Password != input.OldPassWord )
        {
            return BadRequest("Incorrect current password");
        }
        if (userLogin.Password == input.NewPassword)
        {
            return BadRequest("New password must be different from the old password");
        }
        if (input.NewPassword != input.ConfirmPassword)
        {
            return BadRequest("Conform password and New Password must be same......... ");
        }
        userLogin.Password = input.NewPassword;
        await _userLoginRepository.UpdateAsync(userLogin);
        return Ok("Password changed successfully");
    }

    [HttpPost]
    [Route("api/registrations")]
    public async Task<ActionResult<UserDetailsDto>> NewRegistrations(CreateUserDetailsDto input)
    {
        User user = new User(input.FirstName, input.LastName, null, input.MobileNumber, null, input.EmailId, null, null, null, null, null, null, null);
        user.UserTypeId = 2;
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        UserLogin userLogin = new UserLogin(user.Id, input.EmailId, input.Password);
        await _userLoginRepository.AddAsync(userLogin);
        await _userLoginRepository.SaveChangesAsync();

        UserDevice userDevice = new UserDevice(user.Id, null, null, null);
        await _userDerviceRepository.AddAsync(userDevice);




        await _userDerviceRepository.SaveChangesAsync();
        return Ok("Registration successfully");
    }

    [HttpGet]
    [Route("api/users")]
    public async Task<ActionResult<List<UserDetailsDto>>> Getlist()
    {
        var data = await _userRepository.GetList();
        if (data != null)
        {
            var output = _mapper.Map<List<UserDetailsDto>>(data);
            return Ok(output);
        }
        return NotFound("data not found");
    }

    [HttpGet]
    [Route("api/users/{id}")]
    public async Task<ActionResult<UserDetailsDto>> GetById(int id)
    {
        var data = await _userRepository.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound("data not found");
        }
        var output = _mapper.Map<UserDetailsDto>(data);
        return Ok(output);
    }
    [HttpPut]
    [Route("api/users/{id}")]
    public async Task<ActionResult<UserDetailsDto>> Update(UpdateUserDto input, int id)
    {
        User user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return BadRequest("id not Found");
        }
        user.FirstName = input.FirstName;
        user.LastName = input.LastName;
        user.IsMobileConfirmed = input.IsMobileConfirmed;
        user.IsEmailConfirmed = input.IsEmailConfirmed;
        user.DOB = input.DOB;
        user.LocationId = input.LocationId;
        user.Address = input.Address;
        user.PinCode = input.PinCode;
        user.ParentId = input.ParentId;
        user.ProfileImageUrlId = input.ProfileImageUrlId;
        user.UserTypeId = input.Typeid;
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();

        UserLogin userLogin = await _userLoginRepository.GetLoginByUserId(user.Id);
        userLogin.Code = input.Code;
        userLogin.Password = input.Password;
        await _userLoginRepository.UpdateAsync(userLogin);
        await _userLoginRepository.SaveChangesAsync();

        UserDevice userDevice = await _userDerviceRepository.GetbyUserDeviceId(user.Id);
        userDevice.SerialNumber = input.SerialNumber;
        userDevice.DeviceId = input.DeviceId;
        userDevice.MainNumber = input.MainNumber;
        await _userDerviceRepository.UpdateAsync(userDevice);
        await _userDerviceRepository.SaveChangesAsync();

        var output = _mapper.Map<UserDetailsDto>(user);
        return output;
    }
}


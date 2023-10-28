namespace Application.Contracts.UserLogins;

public class UpdateUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? ParentId { get; set; }
    public bool? IsMobileConfirmed { get; set; }
    public bool? IsEmailConfirmed { get; set; }
    public DateTime? DOB { get; set; }
    public int? LocationId { get; set; }
    public string? Address { get; set; }
    public int? PinCode { get; set; }
    public int? ProfileImageUrlId { get; set; }
    public int? Typeid { get; set; }
    public string? Password { get; set; }
    public string? Code { get; set; }
    public string? SerialNumber { get; set; }
    public string? DeviceId { get; set; }
    public string? MainNumber { get; set; }
}

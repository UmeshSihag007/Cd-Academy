using Domain.Models.CommonEntities;
using Domain.Models.Documents;
using Domain.Models.Employees.Locations;
using Domain.Models.Users.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users;

public class User : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? ParentId { get; set; }
    public long MobileNumber { get; set; }
    public bool? IsMobileConfirmed { get; set; }
    public string EmailId { get; set; }
    public bool? IsEmailConfirmed { get; set; }
    public DateTime? DOB { get; set; }
    [ForeignKey("Location")]
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
    public string? Address { get; set; }
    public int? PinCode { get; set; }
    [ForeignKey("Document")]
    public int? ProfileImageUrlId { get; set; }
    public Document? Document { get; set; }
    [ForeignKey("UserType")]
    public int? UserTypeId { get; set; }
    public UserType? UserType { get; set; }
    public User() { }
    public User( string firstname, string lastname,int? parentid,long mobilenumber,bool? ismobileconfirmed,string emailid, bool? isemailconfirmed,DateTime? dob,int? locationid,string? address,int? pincode,int? profileimageurlid,int? usertypeid)
    {  FirstName = firstname; 
       LastName = lastname; 
       ParentId = parentid; 
       MobileNumber = mobilenumber;
       IsMobileConfirmed = ismobileconfirmed; 
       EmailId = emailid; 
       IsEmailConfirmed = isemailconfirmed; 
        DOB = dob; 
        LocationId = locationid;
        Address = address;
        PinCode = pincode; 
        ProfileImageUrlId = profileimageurlid;
        UserTypeId = usertypeid; }
}

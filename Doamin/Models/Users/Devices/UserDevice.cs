using Domain.Models.CommonEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users.Devices;

public class UserDevice : CommanEntity
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
    public string? SerialNumber { get; set; }

    public string? DeviceId { get; set; }
  
    public string? MainNumber { get; set; }

    public UserDevice(int userId,string? serialNumber,string? deviceId,string? mainNumber)
    {
        UserId = userId;
        SerialNumber = serialNumber;
        DeviceId = deviceId;
        MainNumber = mainNumber;
    }
}

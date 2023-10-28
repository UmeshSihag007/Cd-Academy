using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Coupons.Types;

public class CouponType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

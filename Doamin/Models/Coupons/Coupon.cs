using Domain.Models.CommonEntities;
using Domain.Models.Coupons.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Coupons;

public class Coupon : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public decimal? Value { get; set; }
    public bool? IsPercentage { get; set; }
    [ForeignKey("CouponType")]
    public int? TypeId { get; set; }
    public CouponType CouponType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }


}

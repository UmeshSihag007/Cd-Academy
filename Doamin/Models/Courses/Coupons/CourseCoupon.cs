using Domain.Models.CommonEntities;
using Domain.Models.Coupons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Courses.Coupons;

public class CourseCoupon : CommanEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    [ForeignKey("Coupon")]
    public int CouponId { get; set; }
    public Coupon Coupon { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

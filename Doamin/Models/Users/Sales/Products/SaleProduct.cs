using Domain.Models.Courses;
using Domain.Models.Fees;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users.Sales.Products;

public class SaleProduct
{
    public int Id { get; set; }
    [ForeignKey("CourseFee")]
    public int CourseFeeId { get; set; }
    public CourseFee CourseFee { get; set; }
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    [ForeignKey("Sale")]
    public int SaleId { get; set; }
    public Sale Sale { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    public decimal CouponDiscount { get; set; }
    public decimal OtherDiscount { get; set; }
    public decimal PayableAmount { get; set; }
}

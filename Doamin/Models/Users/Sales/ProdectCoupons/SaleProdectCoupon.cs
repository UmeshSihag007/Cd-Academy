using Domain.Models.Coupons;
using Domain.Models.Users.Sales.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users.Sales.ProdectCoupons;

public class SaleProdectCoupon
{
    public int Id { get; set; }
    [ForeignKey("SaleProduct")]
    public int SaleProductId { get; set; }
    public SaleProduct SaleProduct { get; set; }
    public string CouponCode { get; set; }
    [ForeignKey("Coupon")]
    public int CouponId { get; set; }
    public Coupon Coupon { get; set; }
    public int CouponValue { get; set; }
}

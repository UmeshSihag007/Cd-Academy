using Domain.Models.CommonEntities;
using Domain.Models.Users.Sales.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users.Sales;

public class Sale : CommanEntity
{
    public int Id { get; set; }
    [ForeignKey("SaleType")]
    public int SaleTypeId { get; set; }
    public SaleType SaleType { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
    public string Invoice_Number { get; set; }
    public int MaxNumber { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    public decimal CouponDiscount { get; set; }
    public decimal Discount { get; set; }
    public decimal payable_Amount { get; set; }
    public string IGST { get; set; }
    public string SGST { get; set; }
    public decimal Net_Amount { get; set; }
}

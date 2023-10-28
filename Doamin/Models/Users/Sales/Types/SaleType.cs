using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users.Sales.Types;

public class SaleType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

namespace Domain.Models.CommonEntities;

public class CommanEntity
{
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public int CreatedId { get; set; }
    public int? UpdatedId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}

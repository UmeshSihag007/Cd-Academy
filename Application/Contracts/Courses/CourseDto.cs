using Domain.Models.CommonEntities;

namespace Application.Contracts.Courses;

public class CourseDto : CommanEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public string? Icon { get; set; }
    public int? ParentId { get; set; }
    public int? CategoryId { get; set; }
    public int? ModeId { get; set; }
    public int? LevelId { get; set; }
    public int? ThumbUrlId { get; set; }
    public int? OrderNumber { get; set; }
    public int? TotalLeactures { get; set; }
    public int? TotalHours { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsNew { get; set; }
    public bool IsPrimary { get; set; }
}

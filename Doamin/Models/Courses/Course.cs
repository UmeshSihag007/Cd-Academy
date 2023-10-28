using Domain.Models.CommonEntities;
using Domain.Models.Courses.Categories;
using Domain.Models.Courses.Levels;
using Domain.Models.Courses.Modes;
using Domain.Models.Documents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Courses;

public class Course : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public string? Icon { get; set; }
    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public Course Parent { get; set; }
    [ForeignKey("CourseCategory")]
    public int? CategoryId { get; set; }
    public CourseCategory CourseCategory { get; set; }
    [ForeignKey("CourseMode")]
    public int? ModeId { get; set; }
    public CourseMode CourseMode { get; set; }
    [ForeignKey("CourseLevel")]
    public int? LevelId { get; set; }
    public CourseLevel CourseLevel { get; set; }
    [ForeignKey("Document")]
    public int? ThumbUrlId { get; set; }
    public Document Document { get; set; }
    public int? OrderNumber { get; set; }
    public int? TotalLeactures { get; set; }
    public int? TotalHours { get; set; } 
    public DateTime? StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; } = DateTime.Now;
    public bool? IsNew { get; set; } = true;
    public bool? IsPrimary { get; set; }
}

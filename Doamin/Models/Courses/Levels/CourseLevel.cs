using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Courses.Levels;

public class CourseLevel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

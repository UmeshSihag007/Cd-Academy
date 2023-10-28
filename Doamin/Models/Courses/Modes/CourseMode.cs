using System.ComponentModel.DataAnnotations;
namespace Domain.Models.Courses.Modes;

public class CourseMode
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

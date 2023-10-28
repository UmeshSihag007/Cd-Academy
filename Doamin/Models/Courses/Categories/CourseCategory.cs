using Domain.Models.Documents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Courses.Categories;

public class CourseCategory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public CourseCategory Parent { get; set; }
    [ForeignKey("Document")]
    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

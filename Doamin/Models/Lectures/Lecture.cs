using Domain.Models.CommonEntities;
using Domain.Models.Courses;
using Domain.Models.Documents;
using Domain.Models.Employees;
using Domain.Models.Lectures.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Lectures;

public class Lecture : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    [ForeignKey("Course")]
    public int? CourseId { get; set; }
    public Course Course { get; set; }

    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public Lecture Parent { get; set; }

    [ForeignKey("LectureType")]
    public int? TypeId { get; set; }
    public LectureType LectureType { get; set; }
    [ForeignKey("Document")]
    public int? ThumbUrlId { get; set; }
    public Document Document { get; set; }
    public int? Durations { get; set; }
    public string? LectureLinkUrl { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { set; get; }
    public bool? IsNew { get; set; }
    [ForeignKey("LectureBy")]
    public int? LectureById { get; set; }
    public Employee LectureBy { get; set; }
}

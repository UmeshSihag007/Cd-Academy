using Domain.Models.Documents;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Courses.Documents;

public class CourseDocument
{
    [ForeignKey("Document")]
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public CourseDocument(int documentId, int courseId)
    { 
      DocumentId= documentId;
      CourseId= courseId;
    }
}

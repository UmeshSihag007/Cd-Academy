using Domain.Models.Documents;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Lectures.Documents;

public class LectureDocument
{
    [ForeignKey("Document")]
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    [ForeignKey("Lecture")]
    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }
    public LectureDocument(int documentId, int lectureId)
    {
        DocumentId = documentId;    
        LectureId = lectureId;  
    }
}

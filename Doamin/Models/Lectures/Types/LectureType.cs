using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Lectures.Types;

public class LectureType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}

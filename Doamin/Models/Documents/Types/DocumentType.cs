using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Documents.Types;

public class DocumentType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}

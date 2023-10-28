using Domain.Models.CommonEntities;
using Domain.Models.Documents.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Documents;

public class Document : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string? Remark { get; set; }
    [ForeignKey("DocumentType")]
    public int? DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }
}

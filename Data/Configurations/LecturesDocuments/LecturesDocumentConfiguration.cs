using Domain.Models.Lectures.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.LecturesDocuments;

public class LecturesDocumentConfiguration : IEntityTypeConfiguration<LectureDocument>
{
    public void Configure(EntityTypeBuilder<LectureDocument> builder)
    {
        builder.HasKey(x => new { x.DocumentId, x.LectureId });
        builder.Property(p => p.DocumentId)
            .IsRequired();
        builder.Property(p => p.LectureId)
          .IsRequired();

        builder.HasIndex(x => new { x.DocumentId, x.LectureId });
    }
}

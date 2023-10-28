using Domain.Models.Courses.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.CourseDocuments;

public class CourseDocumentConfiguration : IEntityTypeConfiguration<CourseDocument>
{
    public void Configure(EntityTypeBuilder<CourseDocument> builder)
    {
            builder.HasKey(x => new { x.DocumentId, x.CourseId });
            builder.Property(p => p.DocumentId)
                .IsRequired();
            builder.Property(p => p.CourseId)
              .IsRequired();
            builder.HasIndex(x => new { x.DocumentId, x.CourseId });
    }
}

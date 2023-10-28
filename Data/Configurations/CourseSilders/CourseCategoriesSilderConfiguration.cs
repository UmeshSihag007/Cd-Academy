using Domain.Models.Courses.CategoriesSilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.CourseSilder;

public class CourseCategoriesSilderConfiguration : IEntityTypeConfiguration<CourseCategorySilder>
{
    public void Configure(EntityTypeBuilder<CourseCategorySilder> builder)
    {
        builder.HasKey(x => new { x.CategoryId, x.DocumentId });
        builder.Property(p => p.CategoryId);

        builder.Property(p => p.DocumentId);
        
        builder.HasIndex(x => new { x.CategoryId, x.DocumentId });
    }
}

using Domain.Models.Blogs.Documents;
using Domain.Models.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations.Blogs.Documents
{
    public class BlogDocumentConfiguration : IEntityTypeConfiguration<BlogDocument>
    {
        public void Configure(EntityTypeBuilder<BlogDocument> builder)
        {

            builder.HasKey(x => new { x.DocumentId, x.BlogId });
        }
    }
}

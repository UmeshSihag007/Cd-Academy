using Domain.Models.Blogs.Documents;
using Domain.Models.Blogs.ParagraphDocuments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations.Blogs.BlogParagraphDocuments
{
    internal class BlogParagraphDocumentConfiguration : IEntityTypeConfiguration<BlogParagraphDocument>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BlogParagraphDocument> builder)
        {
            builder.HasKey(x => new { x.DocumentId, x.BlogParagraphId });
        }
    }
}

using Domain.Models.Blogs.Paragraphs;
using Domain.Models.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs.ParagraphDocuments
{
    public class BlogParagraphDocument
    {
        [ForeignKey("BlogParagraph")]
        public int? BlogParagraphId { get; set; }
        public BlogParagraph BlogParagraph { get; set; }

        [ForeignKey("Document")]
        public int? DocumentId { get; set; }    
        public Document Document { get; set; }  
    }
}

using Domain.Models.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs.Documents
{
    public class BlogDocument
    {
        [ForeignKey("Blog")]
        public int? BlogId { get; set; }
        public  Blog Blog { get; set; }

        [ForeignKey("Document")]
        public int? DocumentId { get; set; }
        public Document Document { get; set; }

    }
}

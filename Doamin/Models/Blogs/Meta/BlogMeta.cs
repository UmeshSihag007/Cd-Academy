using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs.Meta
{
    public class BlogMeta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Blog")]
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}

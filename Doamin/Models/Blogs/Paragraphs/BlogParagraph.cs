using Domain.Models.CommonEntities;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs.Paragraphs
{
    public class BlogParagraph: CommanEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Blog")]
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }   
        public  string SubTitle { get; set; }
        public string Description { get; set; }
        public Int64 OrderNo { get; set; }

        [ForeignKey("User")]
        public int? AuthorId { get; set; }

        public User User { get; set; }
    }
}

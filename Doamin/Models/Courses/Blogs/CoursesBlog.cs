using Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Courses.Blogs
{
    public class CoursesBlog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Blog")]
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}

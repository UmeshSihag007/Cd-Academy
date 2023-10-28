using Domain.Models.CommonEntities;
using Domain.Models.Courses.Categories;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs
{
    public class Blog: CommanEntity
    {
        [Key]
        public  int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set;}
        public string ThumbImage { get; set;}
        public DateTime TotalReadTime { get; set; }
        public DateTime TotalPracticeTime { get; set;}
        [ForeignKey("Category")]
        public int? CategoryId { get;set; }
        public CourseCategory Category { get; set; }
        [ForeignKey("User")]
        public int ? AuthorId { get; set; }
        public User User { get; set; }

        public string ReaderHint { get; set; }


    }
}

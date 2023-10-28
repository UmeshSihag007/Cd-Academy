using Domain.Models.Lectures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users.Lectures
{
    public class UserLecture
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Lecture")]
        public int? LectureId { get; set; }
        public Lecture Lecture { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User  User { get; set; }

        public bool IsCompleted { get; set; }=false;
        public DateTime StartDate { get;set; }=DateTime.Now;
        public DateTime ComplateDate { get;set; }
    }
}

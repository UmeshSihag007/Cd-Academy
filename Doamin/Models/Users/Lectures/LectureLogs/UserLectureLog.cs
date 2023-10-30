using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users.Lectures.LectureLogs
{
    public class UserLectureLog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserLecture")]
        public int UserLectureId { get; set; }
        public UserLecture UserLecture { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime Date { get; set; }
    }
}

using Domain.Models.CommonEntities;
using Domain.Models.Courses;
using Domain.Models.Fees.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Fees;


public class CourseFee : CommanEntity
{
    [Key]
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    [ForeignKey("Type")]
    public int TypeId { get; set; }
    public CourseFeeType Type { get; set; }
    public decimal Amount { get; set; }
    public decimal? Tax { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

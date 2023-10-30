using Domain.Models.Fees;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Courses.FeeDetails
{
    public class CourseFeeDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CourseFee")]
        public int? FeeId { get;set; }
        public CourseFee CourseFee { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

    }
}

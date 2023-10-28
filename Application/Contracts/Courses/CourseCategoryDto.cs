using Domain.Models.Courses.Categories;
using Domain.Models.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Courses;

public class CourseCategoryDto
{
    public CourseCategory Category { get; set; }

    public Document Document { get; set; }

/*    public int Id { get; set; }
     public string? Name { get; set; }
     public int? ParentId { get; set; }
     public int? DocumentId { get; set; }
     public string? Icon { get; set; }
     public string? Description { get; set; }
*/
   
}

using Domain.Models.Courses.Categories;
using Domain.Models.Documents;

namespace Domain.Models.Courses.CategoriesSilders;

public class CourseCategorySilder
{
   public int CategoryId { get; set; }
    public CourseCategory Category { get; set; }
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public CourseCategorySilder(int categoryId, int documentId)
    {
        CategoryId = categoryId;
        DocumentId = documentId;
    }
}

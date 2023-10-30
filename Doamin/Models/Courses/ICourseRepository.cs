using Domain.Models.Comman;
using Domain.Models.Users.Lectures;

namespace Domain.Models.Courses;

public interface ICourseRepository : IRepository<Course>
{
    Task<List<Course>> GetCoursesByCategoryId(int categoryId);
    Task<List<UserSaleCourse>> GetSaleCourseByUserId(int userId);
    Task<List<UserSaleCourse>> GetNotPurchasedCoursesByUserId(int userId);
    Task<UpCommingClasse> GetUpcomingClasses(int userId);


}

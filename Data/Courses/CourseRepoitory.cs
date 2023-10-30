using Data.Comman;
using Domain.Models.Courses;
using Domain.Models.Users.Lectures;
using Microsoft.EntityFrameworkCore;

namespace Data.Courses;

public class CourseRepoitory : EFRepository<Course>, ICourseRepository
{
    private readonly DataContext _dataContext;
    public CourseRepoitory(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Course>> GetCoursesByCategoryId(int categoryId)
    {
        var data = await _dataContext.Courses
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
        return data;
    }

    public async Task<List<UserSaleCourse>> GetNotPurchasedCoursesByUserId(int userId)
    {
        var purchasedCourses = await(from sale in _dataContext.Sales
                                     join product in _dataContext.SaleProducts on sale.Id equals product.SaleId
                                     where sale.UserId == userId || product.CourseId != userId
                                     select new UserSaleCourse
                                     {
                                         CourseName = product.Course.Name,
                                         UserName = sale.User.FirstName,
                                     }).ToListAsync();
        return purchasedCourses;
    }

    public async Task<List<UserSaleCourse>> GetSaleCourseByUserId(int userId)
    {
        var purchasedCourses = await (from sale in _dataContext.Sales
                                      join product in _dataContext.SaleProducts on sale.Id equals product.SaleId
                                      where sale.UserId == userId
                                      select new UserSaleCourse
                                      {
                                          CourseName = product.Course.Name,
                                          UserName = sale.User.FirstName,
                                      }).ToListAsync();
        return purchasedCourses;
    }
    public async Task<UpCommingClasse> GetUpcomingClasses(int userId)
    {
        var data = await (from lecture in _dataContext.Lectures
                          join course in _dataContext.Courses on lecture.CourseId equals course.Id
                          join lectype in _dataContext.LectureTypes on lecture.TypeId equals lectype.Id
                          join userLecture in _dataContext.UserLectures on lecture.Id equals userLecture.LectureId
                          join user in _dataContext.Users on userLecture.UserId equals user.Id
                          where user.Id == userId 
                          select new UpCommingClasse
                          {
                              CourseName = course.Name,
                              userId = userId,
                             Online = _dataContext.Lectures.Where(l => l.CourseId == course.Id && l.TypeId == 1).ToList(),     
                              OffLine = _dataContext.Lectures.Where(l => l.CourseId == course.Id && l.TypeId == 2).ToList()
                          }
        ).FirstOrDefaultAsync();

        return data;
    }
}

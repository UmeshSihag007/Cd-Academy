using Data.Comman;
using Domain.Models.Courses;
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
}

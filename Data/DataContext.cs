using Domain.Models.Blogs;
using Domain.Models.Blogs.Categories;
using Domain.Models.Blogs.Documents;
using Domain.Models.Blogs.Meta;
using Domain.Models.Blogs.ParagraphDocuments;
using Domain.Models.Blogs.Paragraphs;
using Domain.Models.Coupons;
using Domain.Models.Coupons.Types;
using Domain.Models.Courses;
using Domain.Models.Courses.Blogs;
using Domain.Models.Courses.Categories;
using Domain.Models.Courses.CategoriesSilders;
using Domain.Models.Courses.Coupons;
using Domain.Models.Courses.Documents;
using Domain.Models.Courses.FeeDetails;
using Domain.Models.Courses.Levels;
using Domain.Models.Courses.Modes;
using Domain.Models.Documents;
using Domain.Models.Documents.Types;
using Domain.Models.Employees;
using Domain.Models.Employees.Addresses;
using Domain.Models.Employees.Addresses.Types;
using Domain.Models.Employees.Devices;
using Domain.Models.Employees.Locations;
using Domain.Models.Employees.Logins;
using Domain.Models.Employees.Roles;
using Domain.Models.Fees;
using Domain.Models.Fees.Types;
using Domain.Models.Lectures;
using Domain.Models.Lectures.Documents;
using Domain.Models.Lectures.Types;
using Domain.Models.Menus;
using Domain.Models.Menus.Types;
using Domain.Models.Users;
using Domain.Models.Users.Devices;
using Domain.Models.Users.Lectures;
using Domain.Models.Users.Lectures.LectureLogs;
using Domain.Models.Users.Logins;
using Domain.Models.Users.Sales;
using Domain.Models.Users.Sales.Payments;
using Domain.Models.Users.Sales.ProdectCoupons;
using Domain.Models.Users.Sales.Products;
using Domain.Models.Users.Sales.Types;
using Domain.Models.Users.Types;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<EmployeeRole> EmployeeRoles => Set<EmployeeRole>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeLogIn> EmployeeLogs => Set<EmployeeLogIn>();
    public DbSet<EmployeeDevice> EmployeeDevices => Set<EmployeeDevice>();
    public DbSet<AddressType> AddressTypes => Set<AddressType>();
    public DbSet<EmployeeAddress> EmployeeAddresses => Set<EmployeeAddress>();
    public DbSet<UserType> UserTypes => Set<UserType>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserLogin> UserLogins => Set<UserLogin>();
    public DbSet<UserDevice> UserDevices => Set<UserDevice>();
    public DbSet<MenuType> MenuTypes => Set<MenuType>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<CourseMode> CourseModes => Set<CourseMode>();
    public DbSet<CourseLevel> CourseLevels => Set<CourseLevel>();
    public DbSet<CourseCategory> CourseCategories => Set<CourseCategory>();
    public DbSet<CourseCategorySilder> CourseCategoriesSilders => Set<CourseCategorySilder>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseDocument> CourseDocuments => Set<CourseDocument>();
    public DbSet<LectureType> LectureTypes => Set<LectureType>();
    public DbSet<Lecture> Lectures => Set<Lecture>();
    public DbSet<LectureDocument> LecturesDocuments => Set<LectureDocument>();
    public DbSet<CourseFee> CourseFees => Set<CourseFee>();
    public DbSet<CourseFeeType> CourseFeeTypes => Set<CourseFeeType>();
    public DbSet<CouponType> CouponTypes => Set<CouponType>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<CourseCoupon> CourseCoupons => Set<CourseCoupon>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleType> SaleTypes => Set<SaleType>();
    public DbSet<SaleProduct> SaleProducts => Set<SaleProduct>();
    public DbSet<SaleProdectCoupon> SaleProdectCoupons => Set<SaleProdectCoupon>();

    public DbSet<SalePayment> SalePayments => Set<SalePayment>();
    public DbSet<UserLecture> UserLectures => Set<UserLecture>();
    public DbSet<UserLectureLog> UserLectureLogs => Set<UserLectureLog>();
    public DbSet<BlogCategorie> BlogCategories => Set<BlogCategorie>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<BlogDocument> BlogDocuments => Set<BlogDocument>();
    public DbSet<BlogParagraph> BlogParagraphs => Set<BlogParagraph>();
    public DbSet<BlogParagraphDocument> BlogParagraphDocuments => Set<BlogParagraphDocument>();
    public DbSet<BlogMeta> BlogMetas => Set<BlogMeta>();
    public DbSet<CoursesBlog> CoursesBlogs => Set<CoursesBlog>();
    public DbSet<CourseFeeDetail> CourseFeeDetails => Set<CourseFeeDetail>();




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

using Application.Contracts.Courses;
using Application.Contracts.Menus;
using Application.Contracts.UserLogins;
using AutoMapper;
using Domain.Models.Courses;
using Domain.Models.Courses.Categories;
using Domain.Models.Courses.CategoriesSilders;
using Domain.Models.Documents;
using Domain.Models.Menus;
using Domain.Models.Users;
using Domain.Models.Users.Devices;
using Domain.Models.Users.Logins;

namespace Application.Configrations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Menu, MenuDto>();
        CreateMap<CreateMenuDto, Menu>();
        CreateMap<MenuDto, Menu>();
        CreateMap<UpdateMenuDto, Menu>();
        //...........
        CreateMap<Course, CourseDto>();
        CreateMap<CourseDto, Course>();
        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();

        CreateMap<CourseCategorySilder, CourseCategoryDto>();
        CreateMap<CourseCategoryDto, CourseCategory>();
        CreateMap<CourseCategoryDto, Document>();
        CreateMap<UserSaleCourse, SaleCourseDetailsDto>();
        //...........
        CreateMap<UserLogin, UserLoginVerfiyDto>();
        CreateMap<CreateUserDetailsDto, UserDetails>();
        CreateMap<CreateUserDetailsDto, User>();
        CreateMap<CreateUserDetailsDto, UserLogin>();
        CreateMap<CreateUserDetailsDto, UserDevice>();
        CreateMap<UpdateUserDto, UserDetails>();
        CreateMap<UserDetails, UserDetailsDto>();
        CreateMap<User, UserDetailsDto>();
        CreateMap<UserLogin, UserDetailsDto>();
        CreateMap<UserDevice, UserDetailsDto>();

    }
}

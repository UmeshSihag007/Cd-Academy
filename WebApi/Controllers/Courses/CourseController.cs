using Application.Contracts.Courses;
using AutoMapper;
using Domain.Models.Courses;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Courses;

[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseController(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("api/courses")]
    public async Task<ActionResult<List<CourseDto>>> Getlist()
    {
        var data = await _courseRepository.ListAsync();
        var output = data.Where(x => x.IsDeleted == false);

        var Result = _mapper.Map<List<CourseDto>>(output);
        return Ok(Result);
    }

    [HttpGet]
    [Route("api/courses/{id}")]
    public async Task<ActionResult<CourseDto>> GetById(int id)
    {
        var data = await _courseRepository.GetByIdAsync(id);
        if (data == null || data.IsDeleted == true)
        {
            return NotFound("data not found");
        }
        var output = _mapper.Map<CourseDto>(data);
        return Ok(output);
    }

    [HttpGet]
    [Route("api/courses/category/{categoryId}")]
    public async Task<ActionResult<List<CourseDto>>> GetCourseCategoryById(int categoryId)
    {
        var data = await _courseRepository.GetCoursesByCategoryId(categoryId);
        if (data == null)
        {
            return NotFound("data not found");
        }
        var output = _mapper.Map<List<CourseDto>>(data);
        return Ok(output);
    }

    [HttpPost]
    [Route("api/courses")]
    public async Task<ActionResult<CourseDto>> Create(CreateCourseDto command)
    {
        var data = _mapper.Map<CreateCourseDto, Course>(command);
        var course = await _courseRepository.AddAsync(data);
        var result = _mapper.Map<CourseDto>(course);
        return Ok(result);
    }

    [HttpPut]
    [Route("api/courses/{id}")]
    public async Task<ActionResult<CourseDto>> Update(UpdateCourseDto input, int id)
    {
        var data = await _courseRepository.GetByIdAsync(id);
        if (data == null)
        {
            return BadRequest("data not found");
        }
        data.Name = input.Name;
        data.Description = input.Description;
        data.ShortDescription = input.ShortDescription;
        data.Icon = input.Icon;
        data.ParentId = input.ParentId;
        data.CategoryId = input.CategoryId;
        data.ModeId = input.ModeId;
        data.LevelId = input.LevelId;
        data.ThumbUrlId = input.ThumbUrlId;
        data.OrderNumber = input.OrderNumber;
        data.TotalLeactures = input.TotalLeactures;
        data.TotalHours = input.TotalHours;
        data.StartDate = input.StartDate;
        data.EndDate = input.EndDate;
        data.IsNew = input.IsNew;
        data.IsPrimary = input.IsPrimary;
        data.UpdatedDate = DateTime.Now;
        await _courseRepository.UpdateAsync(data);
        await _courseRepository.SaveChangesAsync();
        var result = await _courseRepository.GetByIdAsync(data.Id);
        var command = _mapper.Map<CourseDto>(result);
        return command;
    }

    [HttpGet]
    [Route("api/courses/{userId}/salecourse")]
    public async Task<ActionResult<List<SaleCourseDetailsDto>>> GetSaleCourseByUserId(int userId)
    {
        var data = await _courseRepository.GetSaleCourseByUserId(userId);

        var Result = _mapper.Map<List<SaleCourseDetailsDto>>(data);
        return Ok(Result);
    }


    /*    [HttpGet]
        [Route("api/users/{userId}/not-purchased-courses")]
        public async Task<ActionResult<List<SaleCourseDetailsDto>>> GetNotPurchasedCoursesByUserId(int userId)
    {
        var notpurchasedCourses = await _courseRepository.GetNotPurchasedCoursesByUserId(userId);


        var result = _mapper.Map<List<SaleCourseDetailsDto>>(notpurchasedCourses);
        return Ok(result);
    }*/


    [HttpGet]
    [Route("api/courses/{userid}/up-coming-classes")]

    public async Task<ActionResult> UpCommingClasses()
    {
        var data = await _courseRepository.GetUpcomingClasses(3);

        if (data == null)
        {
            return NotFound("no data found ......");
        }
        return Ok(data);
    }


    [HttpDelete]
    [Route("api/courses/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course == null || course.IsDeleted == true)
        {
            return BadRequest("Data not Found");
        }
        else
        {
            course.IsDeleted = true;
            await _courseRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}

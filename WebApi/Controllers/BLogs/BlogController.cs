using Application.Contracts.Blogs;
using Application.Contracts.Menus;
using AutoMapper;
using Data.Menus;
using Domain.Models.Blogs;
using Domain.Models.Menus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi.Controllers.BLogs
{
 
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogController(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/list")]
        public async Task<ActionResult<List< BlogDto>>> GetList()
        {
            var blog= await _blogRepository.ListAsync();
            var output = blog.Where(x => x.IsDeleted == false);
            var Result = _mapper.Map<List<BlogDto>>(output);
            return Ok(Result);
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult <BlogDto>> GetById(int id) 
        {
            var blog=await _blogRepository.GetByIdAsync(id);
            if (blog == null || blog.IsDeleted == true)
            {
                return NotFound("data not found");
            }
            var output = _mapper.Map<BlogDto>(blog);
            return Ok(output);
        }  
        [HttpGet]
        [Route("api/[controller]/user/{userid}")]
        public async Task<ActionResult <List< BlogDto>>> GetByUserId(int userid) 
        {
            var blog=await _blogRepository.GetByuserId(userid);
            if (blog == null )
            {
                return NotFound("data not found");
            }
            var data = blog.Where(x => x.IsDeleted == false);

            var output = _mapper.Map<List<BlogDto>>(data);
            return Ok(output);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult<BlogDto>> Create(CreateBlogDto blog) 
        {
            var data = _mapper.Map<CreateBlogDto, Blog>(blog);
            var menu = await _blogRepository.AddAsync(data);
            var result = _mapper.Map<BlogDto>(menu);
            return Ok(result);
        }
    }
}

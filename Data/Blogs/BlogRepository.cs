using Ardalis.Specification.EntityFrameworkCore;
using Data.Comman;
using Domain.Models.Blogs;
using Microsoft.EntityFrameworkCore;

namespace Data.Blogs;

public class BlogRepository : EFRepository<Blog>, IBlogRepository
{
    private readonly DataContext _context;
    public BlogRepository( DataContext context) : base(context)
    {
        _context = context;
    }

   

    public async Task<List<Blog>> GetAll()
    {
        var blog = await _context.Blogs.ToListAsync();
        return blog;
    }

    public async Task<Blog> GetById(int id)
    {
        var blog=await _context.Blogs.FindAsync(id);
        return blog;
    }

    public async Task< List< Blog>> GetByuserId(int userid)
    {
        var blog=await _context.Blogs
            .Where(x=>x.AuthorId == userid)
            .ToListAsync();
        return blog;
    }
}

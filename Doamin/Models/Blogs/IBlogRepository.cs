using Domain.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs
{
    public interface IBlogRepository:IRepository<Blog>
    {
      Task<  Blog> GetById(int id);
      Task<List<Blog>> GetByuserId(int userid);
        Task<List<Blog>> GetAll();

     
    }
}

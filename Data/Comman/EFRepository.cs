using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Models.Comman;

namespace Data.Comman;

public class EFRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public EFRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
    
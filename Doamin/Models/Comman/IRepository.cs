using Ardalis.Specification;

namespace Domain.Models.Comman;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}

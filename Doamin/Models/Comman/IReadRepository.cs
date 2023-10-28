using Ardalis.Specification;
namespace Domain.Models.Comman;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}

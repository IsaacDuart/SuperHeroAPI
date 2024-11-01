using CRUD.DOmain.Entities;

namespace CRUD.DOmain.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Delete(long id);
    Task<T?> GetById(long id);
    Task<IEnumerable<T>> Get();
}
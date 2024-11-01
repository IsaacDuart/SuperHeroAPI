using CRUD.DOmain.Entities;
using CRUD.DOmain.Interfaces;
using CRUD.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly CRUDDbContext _db;

    public BaseRepository(CRUDDbContext db)
    {
        _db = db;
    }
    public virtual async Task<T> Create(T obj)
    {
       _db.Add(obj);
       await _db.SaveChangesAsync();

       return obj;
    }

    public async Task<T> Update(T obj)
    {
       _db.Update(obj);
       await _db.SaveChangesAsync();

       return obj;
    }

    public async Task Delete(long id)
    {
        var obj = await GetById(id);

        if (obj != null)
        {
            _db.Remove(obj);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<T?> GetById(long id)
    {
        return await _db.Set<T>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> Get()
    {
        return await _db.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
}
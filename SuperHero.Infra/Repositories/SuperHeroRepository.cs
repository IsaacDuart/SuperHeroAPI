using CRUD.DOmain.Entities;
using CRUD.DOmain.Interfaces;
using CRUD.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Repositories;

public class SuperHeroRepository : BaseRepository<SuperHero>,ISuperHeroRepository
{
    private readonly CRUDDbContext _db;
    public SuperHeroRepository(CRUDDbContext db) : base(db)
    {
        _db = db;
    }
    

    public async Task<IEnumerable<SuperHero>> SearchByName(string name)
    {
        var allHeroes = await _db.Heroes.AsNoTracking()
                                            .Where(
                                                x => 
                                                    x.Name.ToLower().Contains(name.ToLower())
                                                )
                                            .ToListAsync();
        
        return allHeroes;
    }
}
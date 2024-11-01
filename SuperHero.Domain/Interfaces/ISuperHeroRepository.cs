using CRUD.DOmain.Entities;

namespace CRUD.DOmain.Interfaces;

public interface ISuperHeroRepository : IBaseRepository<SuperHero>
{
  
    Task<IEnumerable<SuperHero>> SearchByName(string name);
}
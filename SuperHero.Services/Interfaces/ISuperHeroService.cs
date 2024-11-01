using CRUD.Services.DTO;

namespace CRUD.Services.Interfaces;

public interface ISuperHeroService
{
    Task<SuperHeroDTO> Create(SuperHeroDTO superHeroDTO);
    Task<SuperHeroDTO> Update(SuperHeroDTO superHeroDTO);
    Task Delete(long id);
    Task<SuperHeroDTO> GetById(long id);
    Task<IEnumerable<SuperHeroDTO>> Get();
    Task<IEnumerable<SuperHeroDTO>> SearchByName(string name);
}
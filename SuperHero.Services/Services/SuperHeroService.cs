using AutoMapper;
using CRUD.Core.Exceptions;
using CRUD.DOmain.Entities;
using CRUD.DOmain.Interfaces;
using CRUD.Services.DTO;
using CRUD.Services.Interfaces;

namespace CRUD.Services.Services;

public class SuperHeroService : ISuperHeroService
{
    private readonly IMapper _mapper;
    private readonly ISuperHeroRepository _superHeroRepository;

    public SuperHeroService(IMapper mapper, ISuperHeroRepository superHeroRepository)
    {
        _mapper = mapper;
        _superHeroRepository = superHeroRepository;
    }
    
    public async Task<SuperHeroDTO> Create(SuperHeroDTO superHeroDTO)
    {
        var superHero = _mapper.Map<SuperHero>(superHeroDTO);
        superHero.Validate();
        
        var superHeroCreated = await _superHeroRepository.Create(superHero);
        return _mapper.Map<SuperHeroDTO>(superHeroCreated);
    }

    public async Task<SuperHeroDTO> Update(SuperHeroDTO superHeroDTO)
    {
        var superHeroExists = await _superHeroRepository.GetById(superHeroDTO.Id);

        if (superHeroExists == null)
        {
            throw new DomainException("Super Hero not found");
        }
        
        var superHero = _mapper.Map<SuperHero>(superHeroDTO);
        superHero.Validate();
        
        var superHeroUpdated = await _superHeroRepository.Update(superHero);
        return _mapper.Map<SuperHeroDTO>(superHeroUpdated);
    }

    public async Task Delete(long id)
    {
        await _superHeroRepository.Delete(id);
    }

    public async Task<SuperHeroDTO> GetById(long id)
    {
        var superHero = await _superHeroRepository.GetById(id);
        
        return _mapper.Map<SuperHeroDTO>(superHero);
    }

    public async Task<IEnumerable<SuperHeroDTO>> Get()
    {
        var allSuperHeroes = await _superHeroRepository.Get();
        
        return _mapper.Map<IEnumerable<SuperHeroDTO>>(allSuperHeroes);
    }

    public async Task<IEnumerable<SuperHeroDTO>> SearchByName(string name)
    {
        var allSuperHeroes = await _superHeroRepository.SearchByName(name);
        return _mapper.Map<IEnumerable<SuperHeroDTO>>(allSuperHeroes);
    }
}
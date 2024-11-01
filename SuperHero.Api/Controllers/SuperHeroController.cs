using AutoMapper;
using CRUD.Api.Utilities;
using CRUD.Api.ViewModels;
using CRUD.Core.Exceptions;
using CRUD.DOmain.Entities;
using CRUD.Services.DTO;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        private readonly IMapper _mapper;

        public SuperHeroController(ISuperHeroService superHeroService, IMapper mapper)
        {
            _superHeroService = superHeroService;
            _mapper = mapper;
        }
        
       
        [HttpPost]
        [Route("/api/v1/superhero/create")]
        public async Task<IActionResult> Create([FromBody] CreateSuperHeroViewModel superHeroViewModel)
        {
            try
            {
                var superHeroDTO = _mapper.Map<SuperHeroDTO>(superHeroViewModel);
                
                var superHeroCreated = await _superHeroService.Create(superHeroDTO);
                
                
                return Ok(new ResultViewModel
                {
                    Message = "Super Hero created",
                    Success = true,
                    Data = superHeroCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/superhero/update")]
        public async Task<IActionResult> Update([FromBody] UpdateViewModel updateViewModel)
        {
            try
            {
                var superHeroDTO = _mapper.Map<SuperHeroDTO>(updateViewModel);
                var superHeroUpdated = await _superHeroService.Update(superHeroDTO);
                
                return Ok(new ResultViewModel
                {
                    Message = "Super Hero updated",
                    Success = true,
                    Data = superHeroUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1/superhero/delete{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _superHeroService.Delete(id);
                
                return Ok(new ResultViewModel
                {
                    Message = "Super Hero deleted",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
               return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/superhero/get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var superHeroList = await _superHeroService.Get();

                if (superHeroList.Count() == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Super Hero list is empty",
                        Success = true,
                        Data = superHeroList
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Super Hero list",
                    Success = true,
                    Data = superHeroList
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/superhero/getbyid{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var superHero = await _superHeroService.GetById(id);

                if (superHero == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Super Hero not found",
                        Success = true,
                        Data = null

                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Super Hero",
                    Success = true,
                    Data = superHero
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/superhero/getbyname{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var allSuperHeroes = await _superHeroService.SearchByName(name);
                
                
                if (allSuperHeroes.Count() == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Super Hero list is empty",
                        Success = true,
                        Data = allSuperHeroes
                    });
                }
                
                return Ok(new ResultViewModel
                {
                    Message = "Super Heroes",
                    Success = true,
                    Data = allSuperHeroes
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
               return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        
    }
}

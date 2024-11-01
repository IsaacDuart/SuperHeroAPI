using AutoMapper;
using CRUD.Api.ViewModels;
using CRUD.DOmain.Entities;
using CRUD.Services.DTO;

namespace CRUD.Api.Profiles;

public class ProfileAutoMapper : Profile
{
    public ProfileAutoMapper()
    {
        CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
        CreateMap<CreateSuperHeroViewModel, SuperHeroDTO>().ReverseMap();
    }
}
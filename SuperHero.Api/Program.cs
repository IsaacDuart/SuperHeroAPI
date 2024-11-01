using System.Configuration;
using AutoMapper;
using CRUD.Api.ViewModels;
using CRUD.DOmain.Entities;
using CRUD.DOmain.Interfaces;
using CRUD.Infra.Context;
using CRUD.Infra.Repositories;
using CRUD.Services.DTO;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

AutoMapperDependenceInjection();
void AutoMapperDependenceInjection()
{
    var autoMapperconfing = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
        cfg.CreateMap<CreateSuperHeroViewModel, SuperHeroDTO>().ReverseMap();
        cfg.CreateMap<UpdateViewModel, SuperHeroDTO>().ReverseMap();

    });
    builder.Services.AddSingleton(autoMapperconfing.CreateMapper());
}


builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<CRUDDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
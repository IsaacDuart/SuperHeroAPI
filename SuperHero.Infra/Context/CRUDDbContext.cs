using CRUD.DOmain.Entities;
using CRUD.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Context;

public class CRUDDbContext : DbContext
{
    public CRUDDbContext()
    {
         
    }
    
    public CRUDDbContext(DbContextOptions<CRUDDbContext> options) : base(options)
    {
        
    }

    /*private readonly string _conectionString = "Server=localhost;Database=CRUDTESTE;Uid=isaac;Pwd=Ferretto12.;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    
        optionsBuilder.UseMySql(_conectionString, ServerVersion.AutoDetect(_conectionString));
    }*/

    public DbSet<SuperHero> Heroes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SuperHeroMap());
    }
}
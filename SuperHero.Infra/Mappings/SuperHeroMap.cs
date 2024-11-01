using CRUD.DOmain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infra.Mappings;

public class SuperHeroMap : IEntityTypeConfiguration<SuperHero>
{
    public void Configure(EntityTypeBuilder<SuperHero> builder)
    {
        builder.ToTable("SuperHero");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseMySqlIdentityColumn()
            .HasColumnType("BIGINT");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasColumnName("name")
            .HasMaxLength(50);
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasColumnName("firstName")
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("varchar(250)")
            .HasColumnName("description")
            .HasMaxLength(50);
        
        
    }
}
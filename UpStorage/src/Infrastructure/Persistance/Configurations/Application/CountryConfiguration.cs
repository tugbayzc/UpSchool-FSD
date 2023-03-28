using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations.Application;

public class CountryConfiguration:IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        //Relationships
        //Fluent Api ile veritabanı configurasyonu(best practice)
        builder.HasMany<City>(x => x.Cities)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);
    }
}
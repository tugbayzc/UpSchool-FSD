using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSchool.Domain.Entities;

namespace UpSchool.Persistance.EntityFramework.Configurations;

public class AccountConfiguration:IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // ID
        builder.HasKey(x => x.Id);
        
        // TITLE
        builder.Property(x=>x.Title).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(150);
        
        // USERNAME
        builder.Property(x=>x.UserName).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(100);
        
        // PASSWORD
        builder.Property(x=>x.Password).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100);
        
        // URL
        builder.Property(x => x.Url).IsRequired(false);
        builder.Property(x => x.Url).HasMaxLength(500);

        // ISFAVOURİTE
        builder.Property(x=>x.IsFavourite).IsRequired();
        
        //CRETATEDON
        builder.Property(x=>x.CreatedOn).IsRequired();
        
        // LASTMODİFİEDON
        builder.Property(x=>x.LastModidifiedOn).IsRequired(false);

        builder.ToTable("Accounts");

    }
}
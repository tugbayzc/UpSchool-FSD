using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations.Application;

public class AccountCategoryConfiguration:IEntityTypeConfiguration<AccountCategory>
{
    public void Configure(EntityTypeBuilder<AccountCategory> builder)
    {
        //Relationships
        builder.HasOne<Account>(X=>X.Account)
            .WithMany(x=>x.AccountCategories)
            .HasForeignKey(x=>x.AccountId);
        builder.HasOne<Category>(x=>x.Category)
            .WithMany(x => x.AccountCategories)
            .HasForeignKey(x => x.CategoryId);
    }
}
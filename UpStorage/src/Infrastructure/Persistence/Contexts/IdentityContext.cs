using System.Reflection;
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public class IdentityContext :IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //ignores
        modelBuilder.Ignore<Account>();
        modelBuilder.Ignore<Country>();
        modelBuilder.Ignore<City>();
        modelBuilder.Ignore<Address>();
        modelBuilder.Ignore<Category>();
        modelBuilder.Ignore<AccountCategory>();



        base.OnModelCreating(modelBuilder);
    }
}
using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Contexts;

public class ApplicationDbContext:DbContext,IApplicationDbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //ignores
        modelBuilder.Ignore<User>();
        modelBuilder.Ignore<Role>();
        modelBuilder.Ignore<UserRole>();
        modelBuilder.Ignore<UserToken>();
        modelBuilder.Ignore<UserClaim>();
        modelBuilder.Ignore<UserLogin>();
        modelBuilder.Ignore<RoleClaim>();


        base.OnModelCreating(modelBuilder);
    }
}
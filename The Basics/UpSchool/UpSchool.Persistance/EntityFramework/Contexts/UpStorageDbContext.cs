using Microsoft.EntityFrameworkCore;
using UpSchool.Domain.Entities;
using UpSchool.Persistance.EntityFramework.Configurations;
using UpSchool.Persistance.EntityFramework.Seeders;

namespace UpSchool.Persistance.EntityFramework.Contexts;

public class UpStorageDbContext:DbContext 
{
    public UpStorageDbContext(DbContextOptions<UpStorageDbContext> options):base(options)
    {
        
    }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());

        modelBuilder.ApplyConfiguration(new AccountSeeder());
        
        base.OnModelCreating(modelBuilder);
    }
    
    
}
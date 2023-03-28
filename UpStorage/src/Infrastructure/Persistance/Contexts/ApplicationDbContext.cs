using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Contexts;

public class ApplicationDbContext:DbContext
{
    public DbSet<Account> Accounts { get; set; }
    
}
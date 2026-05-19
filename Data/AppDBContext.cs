using ItransitionProjectMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ItransitionProjectMVC.Data;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder); 
    }
}
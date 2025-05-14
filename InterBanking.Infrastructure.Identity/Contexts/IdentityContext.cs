using InterBanking.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InterBanking.Infrastructure.Identity.Contexts;

public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public IdentityContext(DbContextOptions<IdentityContext> opts) : base(opts){}

    protected void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
using Microsoft.AspNetCore.Identity;

namespace InterBanking.Infrastructure.Identity.Entities;

public class ApplicationRole : IdentityRole
{
    public ICollection<ApplicationUser> Users { get; set; } = [];
}
using Microsoft.AspNetCore.Identity;

namespace InterBanking.Infrastructure.Identity.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string NationalId { get; set; }
    public string Address { get; set; } 
    public ICollection<ApplicationRole> Roles { get; set; } = [];
}

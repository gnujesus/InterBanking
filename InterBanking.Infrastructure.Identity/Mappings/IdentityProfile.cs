using AutoMapper;
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth.Register;
using InterBanking.Infrastructure.Identity.Entities;

namespace InterBanking.Infrastructure.Identity.Mappings;

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
    }
}

/* Application User

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string NationalId { get; set; }
    public string Address { get; set; } 
    public ICollection<ApplicationRole> Roles { get; set; } = [];
    
    + IdentityUser properties
*/

/* UserViewModel
 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } 
 
*/


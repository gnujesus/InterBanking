
using InterBanking.Core.Application.ViewModels.Shared;

namespace InterBanking.Core.Application.ViewModels.User;

public class UserViewModel 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } 
}
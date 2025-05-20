using System.Reflection.Metadata.Ecma335;

namespace InterBanking.Core.Application.ViewModels.User.Auth;

public class AuthResponseViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}
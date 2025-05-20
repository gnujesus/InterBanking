using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth.Login;

namespace InterBanking.Core.Application.Interfaces.Services;

public interface ITokenService
{
    Task<string> GenerateToken(UserViewModel vm);
}
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth.Register;

namespace InterBanking.Core.Application.Interfaces.Services;

public interface IUserService 
{
    Task<UserViewModel> Add(RegisterViewModel rvm);

    Task<UserViewModel> GetById(int id);
    
    Task<List<UserViewModel>> GetAll();

    Task<UserViewModel> Update(RegisterViewModel svm, int id);

    Task Delete(UserViewModel vm);
}
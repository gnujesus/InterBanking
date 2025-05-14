using AutoMapper;
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth.Register;
using InterBanking.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace InterBanking.Infrastructure.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;
    
    public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }
    
    public Task<UserViewModel> Add(RegisterViewModel rvm)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserViewModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> Update(RegisterViewModel svm, int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(UserViewModel vm)
    {
        throw new NotImplementedException();
    }
}
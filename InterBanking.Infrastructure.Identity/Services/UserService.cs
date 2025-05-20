using AutoMapper;
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth;
using InterBanking.Core.Application.ViewModels.User.Auth.Login;
using InterBanking.Core.Application.ViewModels.User.Auth.Register;
using InterBanking.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace InterBanking.Infrastructure.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IMapper mapper, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<UserViewModel> Add(RegisterViewModel rvm)
    {
        var user = _mapper.Map<ApplicationUser>(rvm);
        var result = await _userManager.CreateAsync(user, rvm.Password);

        if (!result.Succeeded) throw new Exception("User creation failed");

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<AuthResponseViewModel> Login(LoginViewModel lvm)
    {
        var user = lvm.UserName != null
            ? await _userManager.FindByNameAsync(lvm.UserName)
            : await _userManager.FindByEmailAsync(lvm.Email);

        if (user == null)
            throw new Exception("Invalid username or password");

        var result = await _signInManager.PasswordSignInAsync(user, lvm.Password, false, false);

        if (!result.Succeeded)
            throw new Exception("Invalid username or password");

        var userViewModel = _mapper.Map<UserViewModel>(user);

        var token = await _tokenService.GenerateToken(userViewModel);
        var authResponseViewModel = _mapper.Map<AuthResponseViewModel>(user);
        authResponseViewModel.Token = token;

        return authResponseViewModel;
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
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth.Register;
using Microsoft.AspNetCore.Mvc;

namespace Api.InterBanking.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthenticationController : Controller
{
    private readonly IUserService _userService;

    public AuthenticationController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Register([FromBody]RegisterViewModel rvm)
    {
        UserViewModel vm = await _userService.Add(rvm);
        return Ok(vm);
    }
}
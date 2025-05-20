using System.IdentityModel.Tokens.Jwt;
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.InterBanking.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("Accounts")]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountService.GetAll();

        return Ok(accounts);
    }

    [HttpGet("Account")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await _accountService.GetById(id);

        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaveAccountViewModel svm)
    {
        // 1. How is the user's ID stored inside the JWT? 
        // Ans: It's stored in a claim.

        // 2. How can you access claims inside the controller once the JWT is validated?
        // Ans: Decrypting the JWT in order to get the data, therefore gaining access to the ID
        // Correct ans: There's a User class that contains all this data, you find the claim by it's type or literal string
        // JwtRegisteredClaimNames.Sub or "sub"

        // 3. What claim type do you expect for the user ID?
        // Ans: a .Sub claim, idk the class, but is a sub, since it's the subject.

        // 4. Once you get the ID as a string, how do you safely use it in your new entity?
        // Ans: I'll add it to the smv.UserId, so the saved account belongs to the currently logged in user

        // 5. What happens if the claim is missing or the user is not authenticated? How do you handle that?
        // The API automatically returns a 401 code if no valid JWT is provided, so you must be logged in to be able to
        // create an account.

        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        // Can also be
        // var idClaim = User.FindFirst("nameid");

        // Why is this NameIdentifier and not sub?
        // Ans: JWT uses Subject as a standard, but ASP.NET Core Identity uses claims based on the System.Security.Claims namespace.
        // Sub is tightly couped with ClaimsPrincipal, this is why Identity uses NameIdentifier (chatgpt will have a longer explanation)

        // idClaim is an object, not a string. You have to retrieve the value
        svm.UserId = (string)idClaim.Value;
        var account = await _accountService.Add(svm);

        return Ok(account);
    }
}
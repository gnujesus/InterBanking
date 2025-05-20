using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Application.ViewModels.User.Auth.Login;
using InterBanking.Infrastructure.Identity.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace InterBanking.Infrastructure.Identity.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> GenerateToken(UserViewModel vm)
    {
        var user = vm.UserName != null
            ? await _userManager.FindByNameAsync(vm.UserName)
            : await _userManager.FindByEmailAsync(vm.Email);

        // First -> read settings
        var jwtSettings = _configuration.GetSection("JwtSettings");

        // NOTE: Must be converted to int32 because it's stored as a string on the appsettings.json.
        // It's going to be used for calculations, so it must be an integer.
        var expiryMinutes = Convert.ToInt32((string)jwtSettings["ExpiryMinutes"]);


        // Second -> Create security key

        // NOTE: Must be symmetric because this same key is used for signing and verification
        // Symmetric cryptography uses a single key for encryption and decryption 

        // NOTE2: Encoding.UTF8.GetBytes -> Because the key is stored as a string, but must be in byte array format to be encrypted
        // UTF-8 Encoding is used to convert a given string into bytes 
        // They must be bytes because algorithms like HMAC work with byte arrays, or raw binary data in other words. They don't
        // use strings. UTF8.GetBytes returns the needed array of bytes.
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((string)jwtSettings["SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Third -> Create claims (data encoded into the token)

        // NOTE: Claims are pieces of info stored on the JWT. 
        // Sub -> Subject (user id)
        // Jti -> Token unique id
        // The claim class is used (on c#) to represent a keyvalue pair on the token.

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Forth -> Create token

        // NOTE: issuer, audience and claims are raw data since they're just strings or arrays. Basic values, no additional info needed
        // Meanwhile, expires is a DateTime object, and the signingCredentials are teh creds for the token.
        var token = new JwtSecurityToken(
            jwtSettings["Issuer"],
            jwtSettings["Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        // NOTE: Since the method is async,  we have to wrap teh result (the token) on a task, so the method signature can
        // return a Task<string> to match the async. This allows to maintain the async consistency.
        // Another solution would be to just not use async.
        // JwtSecurityToken has to be written and not returned directly since the token is a complex object, and must be
        // serialized in a string format              

        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
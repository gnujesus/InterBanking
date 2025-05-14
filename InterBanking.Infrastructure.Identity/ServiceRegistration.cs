using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Infrastructure.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterBanking.Infrastructure.Identity;

public static class ServiceRegistration
{
   public static void AddIdentityInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddTransient<IUserService, UserService>();
   }
}
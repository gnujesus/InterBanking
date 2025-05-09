using System.Reflection;
using System.Reflection.Metadata;
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterBanking.Core.Application;

// Extension Method - Decorator 

// NOTES:
// 1. Extension methods must be static

public static class ServiceRegistration
{
    public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // Assembly.GetExecutingAssembly -> Search on the layer executing this method 
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        #region Services
        
        services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>)); 
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ITransactionService, TransactionService>();
        
        #endregion
        
    }
}
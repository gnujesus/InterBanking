using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterBanking.Infrastructure.Persistence;

public static class ServiceRegistration
{
   
   // NOTE: You must use this on the first parameter of a service registration, otherwise, it will not be recognized as an extension method on Program.cs
   
   /*
    * Explanation:
    * C# has an abstraction that allows to extend a method that can't be modified, passing the first parameter as a this and passing the method.
    * 
    */
   public static void AddPersistenceInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
   {
      #region Repositories
      
         services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
         services.AddTransient<ITransactionRepository, TransactionRepository>(); 
         services.AddTransient<IAccountRepository, AccountRepository>(); 
         services.AddTransient<IBeneficiaryRepository, BeneficiaryRepository>(); 

      #endregion 
   }
}
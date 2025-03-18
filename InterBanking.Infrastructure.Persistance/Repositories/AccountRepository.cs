using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Domain.Entities;
using InterBanking.Infrastructure.Persistance.Contexts;

namespace InterBanking.Infrastructure.Persistance.Repositories;

public class AccountRepository : GenericRepository<Account> , IAccountRepository
{
    private readonly ApplicationContext _dbContext;
    
    public AccountRepository(ApplicationContext dbContext)  : base(dbContext)
    {
       _dbContext = dbContext; 
    }
}
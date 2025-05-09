using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Domain.Entities;
using InterBanking.Infrastructure.Persistence.Contexts;

namespace InterBanking.Infrastructure.Persistence.Repositories;

public class AccountRepository : GenericRepository<Account> , IAccountRepository
{
    private readonly ApplicationContext _dbContext;
    
    public AccountRepository(ApplicationContext dbContext)  : base(dbContext)
    {
       _dbContext = dbContext; 
    }
}
using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Domain.Entities;
using InterBanking.Infrastructure.Persistence.Contexts;

namespace InterBanking.Infrastructure.Persistence.Repositories;

public class TransactionRepository : GenericRepository<Transaction> , ITransactionRepository
{
    private readonly ApplicationContext _dbContext;
    
    public TransactionRepository(ApplicationContext dbContext)  : base(dbContext)
    {
       _dbContext = dbContext; 
    }
}
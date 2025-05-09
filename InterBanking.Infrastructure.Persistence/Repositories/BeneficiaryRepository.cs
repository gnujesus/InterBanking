using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Domain.Entities;
using InterBanking.Infrastructure.Persistence.Contexts;

namespace InterBanking.Infrastructure.Persistence.Repositories;

public class BeneficiaryRepository : GenericRepository<Beneficiary> , IBeneficiaryRepository
{
    private readonly ApplicationContext _dbContext;

    public BeneficiaryRepository(ApplicationContext dbContext)  : base(dbContext)
    {
       _dbContext = dbContext; 
    }
}
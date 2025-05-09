using AutoMapper;
using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.Account;
using InterBanking.Core.Domain.Entities;

namespace InterBanking.Core.Application.Services;

public class AccountService : GenericService<Account, AccountViewModel, SaveAccountViewModel>, IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
    }
}
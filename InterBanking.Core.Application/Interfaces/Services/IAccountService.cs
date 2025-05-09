using InterBanking.Core.Application.ViewModels.Account;
using InterBanking.Core.Domain.Entities;

namespace InterBanking.Core.Application.Interfaces.Services;

public interface IAccountService : IGenericService<Account, AccountViewModel, SaveAccountViewModel>
{
}
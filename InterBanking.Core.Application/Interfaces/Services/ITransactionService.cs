using InterBanking.Core.Application.ViewModels.Transaction;
using InterBanking.Core.Domain.Entities;

namespace InterBanking.Core.Application.Interfaces.Services;

public interface ITransactionService : IGenericService<Transaction, TransactionViewModel, SaveTransactionViewModel>
{
}
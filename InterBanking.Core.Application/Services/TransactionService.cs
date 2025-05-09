using AutoMapper;
using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.ViewModels.Transaction;
using InterBanking.Core.Domain.Entities;

namespace InterBanking.Core.Application.Services;

public class TransactionService : GenericService<Transaction, TransactionViewModel, SaveTransactionViewModel>, ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
    }
}
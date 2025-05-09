using System.ComponentModel.DataAnnotations;
using InterBanking.Core.Application.ViewModels.Transaction;
using InterBanking.Core.Domain.Enums;

namespace InterBanking.Core.Application.ViewModels.Account;

public class SaveAccountViewModel
{
        public int AccountNumber { get; set; }

        [Range(0, 200000.00)]
        public double Amount { get; set; } = 0;
        
        public AccountTypes AccountType { get; set; } = AccountTypes.Savings;

        public Currencies Currency { get; set; } = Currencies.DOP;
}
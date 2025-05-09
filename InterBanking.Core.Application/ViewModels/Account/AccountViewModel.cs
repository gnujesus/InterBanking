using InterBanking.Core.Application.ViewModels.Transaction;
using InterBanking.Core.Domain.Enums;

namespace InterBanking.Core.Application.ViewModels.Account;

public class AccountViewModel
{
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        public string? AccountType { get; set; }

        // Owner
        public int UserId { get; set; } // FK
        public string? Currency { get; set; } 

        // Navegation Properties
        public List<TransactionViewModel> Transactions { get; set; }
}
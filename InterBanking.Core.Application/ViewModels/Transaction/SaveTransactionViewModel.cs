using System.Security.Authentication.ExtendedProtection;
using InterBanking.Core.Application.ViewModels.Account;

namespace InterBanking.Core.Application.ViewModels.Transaction;

public class SaveTransactionViewModel
{

        public string? Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int DestinationAccountId { get; set; }

        // Navegation Properties
        public AccountViewModel OriginAccount { get; set; }
        public AccountViewModel DestinationAccount { get; set; }
        
        // We're going to have to make a query for this one
        // public Account DestinationAccount { get; set; }
}
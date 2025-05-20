using System.Security.Authentication.ExtendedProtection;
using InterBanking.Core.Application.ViewModels.Account;

namespace InterBanking.Core.Application.ViewModels.Transaction;

public class SaveTransactionViewModel
{
    public string? Description { get; set; } = string.Empty;
    public double Amount { get; set; }
    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterBanking.Core.Domain.Enums;
using InterBanking.Core.Domain.Shared;

namespace InterBanking.Core.Domain.Entities
{
    public class Account : AuditableBaseEntity
    {
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        
        // Made this nullable, explanation on gpt
        
        /*
         * Explanation: 
         * 
         * The default account type was set to AccountTypes.Savings, this means that if no account type is passed, 
         * the default value for an enum gets passed, which is 0. In this case, 0 could be none or could be an enum, and
         * EF doesn't know. For this, I make the property nullable, so if nothing gets passed, it defaults to the default
         * value.
         *
         * I don't completely understand what I'm saying, but that's kinda what I understand right now. I should revisit this later,
         * but for now, making it nullable gets rid of an error.
         *
         * NOTE: This also applies for Currency.
         */
        public AccountTypes? AccountType { get; set; } = AccountTypes.Savings;

        // Owner
        public int UserId { get; set; } // FK
        public Currencies? Currency { get; set; } = Currencies.DOP;

        // Navegation Properties
        public List<Transaction> OriginTransactions { get; set; } // Transactions in which this account was the origin
        public List<Transaction> DestinationTransactions { get; set; } // Transactions in which this account was the destination
    }
}

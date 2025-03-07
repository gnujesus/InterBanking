using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterBanking.Core.Domain.Enums;
using InterBanking.Core.Domain.Shared;

namespace InterBanking.Core.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int AccountNumber { get; set; }
        public int Amount { get; set; }
        public AccountTypes AccountType { get; set; } = AccountTypes.Savings;

        public int UserId { get; set; } // FK
    }
}

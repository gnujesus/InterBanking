using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterBanking.Core.Domain.Shared;

namespace InterBanking.Core.Domain.Entities
{
    public class Transaction : AuditableBaseEntity
    {
        public string? Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int OriginAccountId { get; set; } // Fk
        public int DestinationAccountId{ get; set; } // Fk


        // Navegation Properties
        public Account OriginAccount { get; set; }
        public Account DestinationAccount { get; set; }

    }
}

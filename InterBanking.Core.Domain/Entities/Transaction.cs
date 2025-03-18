using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterBanking.Core.Domain.Shared;

namespace InterBanking.Core.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string? Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int OriginAccountId { get; set; } // Fk
        public int DestinationAccountId{ get; set; } // Fk


        // Navegation Properties
        public Account OriginAccount { get; set; }
        
        // We're going to have to make a query for this one
        // public Account DestinationAccount { get; set; }

    }
}

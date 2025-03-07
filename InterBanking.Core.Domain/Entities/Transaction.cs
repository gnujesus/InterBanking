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
        public int Amount { get; set; }
        public int FromAccountId { get; set; } // Fk
        public int ToAccountId{ get; set; } // Fk


        // Navegation Properties
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }

    }
}

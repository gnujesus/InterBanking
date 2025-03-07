using System.Security.Cryptography.X509Certificates;
using InterBanking.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterBanking.Infrastructure.Persistance.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opts) : base(opts){}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

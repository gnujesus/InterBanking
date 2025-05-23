﻿using System.Security.Cryptography.X509Certificates;
using InterBanking.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using InterBanking.Core.Domain.Enums;

namespace InterBanking.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opts) : base(opts){}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Fluent API 

            /*
            * Just for practice purposes, 
            * but these are not needed, since it's convention over config
            */


            /*
                #region Tables
                modelBuilder.Entity<Account>()
                    .ToTable("Accounts");

                modelBuilder.Entity<Transaction>()
                    .ToTable("Transactions");
                #endregion

                #region Pks
                modelBuilder.Entity<Account>()
                    .HasKey(a => a.Id);

                modelBuilder.Entity<Transaction>()
                    .HasKey(a => a.Id);
                #endregion
            */

            #region Relations

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.OriginAccount)
                .WithMany(a => a.OriginTransactions)
                .HasForeignKey(t => t.OriginAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.DestinationAccount)
                .WithMany(a => a.DestinationTransactions)
                .HasForeignKey(t => t.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            
            #endregion
            
            #region Account Properties 
            
            // This one looks like it's going to blow up
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .HasDefaultValue(AccountTypes.Savings);
            
            #endregion
            
            #region Transaction Properties 
            
            // This one looks like it's going to blow up
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasDefaultValue(0);
            
            
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Description)
                .HasMaxLength(255);
                
            #endregion
            
            #region Beneficiary Properties
                
            modelBuilder.Entity<Beneficiary>()
                .Property(t => t.Alias)
                .HasMaxLength(100);
            
            #endregion
        }
    }
}

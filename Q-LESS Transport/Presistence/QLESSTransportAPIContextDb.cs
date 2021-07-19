using Microsoft.EntityFrameworkCore;
using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence
{
    public class QLESSTransportAPIContextDb : DbContext
    {
        public QLESSTransportAPIContextDb(DbContextOptions<QLESSTransportAPIContextDb> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardTypeDetails> CardTypeDetails { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<FareAmount> FareAmounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardTypeDetails>()
                .HasMany<Card>(p => p.Card)
                .WithOne(c => c.CardTypeDetails)
                .HasForeignKey(c => c.CardTypeDetailsId);

            modelBuilder.Entity<Card>()
                .HasMany<DiscountCard>(p => p.DiscountCard)
                .WithOne(c => c.Card)
                .HasForeignKey(c => c.CardId);

            modelBuilder.Entity<TransactionType>()
                .HasMany<Transaction>(p => p.Transaction)
                .WithOne(c => c.TransactionType)
                .HasForeignKey(c => c.TransactionCode);

            modelBuilder.Entity<Card>()
                .HasMany<Transaction>(p => p.Transaction)
                .WithOne(c => c.Card)
                .HasForeignKey(c => c.CardId);

        }
    }
}

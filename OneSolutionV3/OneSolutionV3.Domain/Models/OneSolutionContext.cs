using System.Data.Entity;

namespace OneSolutionV3.Domain.Models
{
    public class OneSolutionContext : DbContext
    {
        public OneSolutionContext() : base("OneSolutionCN")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CategoryStructure> CategoryStructure { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<MoneyCount> MoneyCounts { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtPayment> DebtPayments { get; set; }
        public DbSet<FundTransfer> FundTransfers { get; set; }
        public DbSet<RecursiveTransaction> RecursiveTransactions { get; set; }
        public DbSet<RecursiveTransactionDetail> RecursiveTransactionDetails { get; set; }
    }
}

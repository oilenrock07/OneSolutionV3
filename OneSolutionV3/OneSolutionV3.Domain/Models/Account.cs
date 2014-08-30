using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OneSolutionV3.Domain.Models
{
    public class Account
    {
        public enum AccountTypes : int
        {
            [Description("Cash In Hand")]
            CashInHand = 1,

            [Description("Savings")]
            Savings = 2,

            [Description("Checking")]
            Checking = 3,

            [Description("Credit Card")]
            CreditCard = 4
        }

        [Key]
        public int AccountId { get; set; }
        public int AccountType { get; set; }

        [StringLength(100)]
        public string AccountName { get; set; }

        public double Amount { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Bank")]
        public int ? BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

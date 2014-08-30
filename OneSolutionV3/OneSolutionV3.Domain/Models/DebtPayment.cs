using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OneSolutionV3.Domain.Models
{
    public class DebtPayment
    {
        [Key]
        public int DebtPaymentId { get; set; }
        
        [ForeignKey("Debt")]
        public int DebtId { get; set; }
        public virtual Debt Debt { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public double Amount { get; set; }
        public DateTime DatePaid { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }
    }
}

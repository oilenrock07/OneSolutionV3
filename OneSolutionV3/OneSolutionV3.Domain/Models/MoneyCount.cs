using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class MoneyCount
    {
        [Key]
        public int MoneyCountId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        public double Discrepancy { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        [StringLength(1000)]
        public string Remarks { get; set; }
    }
}

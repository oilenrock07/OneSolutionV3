using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class FundTransfer
    {
        [Key]
        public int FundTransferId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("FromAccount")]
        public int FromAccountId { get; set; }
        public Account FromAccount { get; set; }

        [ForeignKey("ToAccount")]
        public int ToAccountId { get; set; }
        public Account ToAccount { get; set; }

        public double Amount { get; set; }
        public DateTime DateTransfer { get; set; }
        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }
    }
}

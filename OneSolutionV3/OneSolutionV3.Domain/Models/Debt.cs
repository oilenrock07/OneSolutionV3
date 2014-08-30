using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OneSolutionV3.Domain.Models
{
    public class Debt
    {
        public enum DebtStatus : int
        {
            [Description("Unpaid")]
            Unpaid = 1,
            [Description("Paid")]
            Paid = 2,
            [Description("Bequested")]
            Bequested = 3,
        }

        [Key]
        public int DebtId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User{ get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact{ get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public double Amount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMyDebt { get; set; }
        public int Status { get; set; }

        public DateTime DebtDate { get; set; }
        public DateTime ? DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ? BequestedDate { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public Debt()
        {
            this.Status = 1;
        }
    }
}

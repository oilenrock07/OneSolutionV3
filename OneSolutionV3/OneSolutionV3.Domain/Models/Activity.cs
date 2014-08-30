using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class Activity
    {
        public enum ActivityTypes : int
        {
            Registration = 0,
            Transaction = 1,
            MoneyCount = 2,
            FundTransfer = 3,
            Debt = 4,
            DebtPayment = 5
        }

        [Key]
        public int ActivityId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        public int ActivityType { get; set; }
    }
}

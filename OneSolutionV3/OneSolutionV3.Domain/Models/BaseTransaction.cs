using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OneSolutionV3.Domain.Models
{
    public abstract class BaseTransaction
    {
        public double Amount { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
    }
}

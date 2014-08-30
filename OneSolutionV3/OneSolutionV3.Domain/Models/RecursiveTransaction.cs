using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class RecursiveTransaction
    {
        [Key]
        public int RecursiveTransactionId { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}

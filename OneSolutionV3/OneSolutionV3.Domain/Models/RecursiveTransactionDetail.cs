using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class RecursiveTransactionDetail : BaseTransaction
    {
        [Key]
        public int RecursiveTransactionDetailId { get; set; }

        [ForeignKey("RecursiveTransaction")]
        public int RecursiveTransactionId { get; set; }
        public RecursiveTransaction RecursiveTransaction { get; set; }
    }
}

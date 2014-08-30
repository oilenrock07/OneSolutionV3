using System.Collections.Generic;

namespace OneSolutionV3.Domain.DTO.RecursiveTransaction
{
    public class RecursiveTransactionViewModel
    {
        public int RecursiveTransactionId { get; set; }
        public string Name { get; set; }

        public IEnumerable<RecursiveDetail> TransactionList { get; set; }

        public RecursiveTransactionViewModel()
        {
            this.TransactionList = new List<RecursiveDetail>();
        }
    }
}

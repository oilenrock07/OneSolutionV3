
namespace OneSolutionV3.Domain.DTO.RecursiveTransaction
{
    public class RecursiveDetail
    {
        public int RecursiveTransactionDetailId { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }

        public string CategoryName { get; set; }
        public string AccountName { get; set; }

        public double Amount { get; set; }
        public string Remarks { get; set; }
        public bool IsExpense { get; set; }
    }
}

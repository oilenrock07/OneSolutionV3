
namespace OneSolutionV3.Domain.DTO.Transaction
{
    public class TransactionUpdate
    {
        public int TransactionId { get; set; }
        public bool IsExpense { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
    }
}

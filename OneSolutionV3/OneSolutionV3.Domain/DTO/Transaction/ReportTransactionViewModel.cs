using System;

namespace OneSolutionV3.Domain.DTO.Transaction
{
    public class ReportTransactionViewModel
    {
        public int TransactionId { get; set; }

        public string CategoryName { get; set; }
        public string AccountName { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }

        public double Amount { get; set; }
        public bool IsExpense { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
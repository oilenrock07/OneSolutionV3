using System;

namespace OneSolutionV3.Common.Model
{
    public class ImportTransaction
    {
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public string AccountType { get; set; }
        public string Category { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;

namespace OneSolutionV3.Domain.DTO.Transaction
{
    public class AmountAndDate
    {
        public double Amount { get; set; }
        public DateTime ? TransactionDate { get; set; }
    }
}

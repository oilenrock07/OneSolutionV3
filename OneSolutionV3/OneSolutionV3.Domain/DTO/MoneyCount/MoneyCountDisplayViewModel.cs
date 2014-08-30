using System;

namespace OneSolutionV3.Domain.DTO.MoneyCount
{
    public class MoneyCountDisplayViewModel
    {
        public int MoneyCountId { get; set; }

        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public double Amount { get; set; }

        public double Discrepancy { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime DateCreated { get; set; }

        public string Remarks { get; set; }
    }
}

using System;

namespace OneSolutionV3.Domain.DTO.Debt
{
    public class DebtPaymentViewModel
    {
        public int DebtPaymentId { get; set; }

        public double Amount { get; set; }
        public DateTime DatePaid { get; set; }

        public string Comment { get; set; }
        public string AccountName { get; set; }
    }
}

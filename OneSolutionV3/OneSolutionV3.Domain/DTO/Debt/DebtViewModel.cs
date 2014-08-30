using System;
using System.Linq;
using System.Collections.Generic;

namespace OneSolutionV3.Domain.DTO.Debt
{
    public class DebtViewModel
    {
        public int DebtId { get; set; }
        public int AccountId { get; set; }

        public string AccountName { get; set; }
        public string ContactName { get; set; }
        public string Comment { get; set; }

        public DateTime DebtDate { get; set; }
        public DateTime ? DueDate { get; set; }
        
        public double Amount { get; set; }
        public bool IsMyDebt { get; set; }

        public int Status { get; set; }

        public IEnumerable<DebtPaymentViewModel> Payments { get; set; }

        public string IsMyDebtDescription
        {
            get
            {
                return IsMyDebt ? "My Debt" : "Others Debt";
            }
        }

        public double Balance
        {
            get
            {
                return Amount - (Payments != null ? Payments.Sum(e => e.Amount) : 0);
            }
        }

        public bool IsOverDue
        {
            get
            {
                return DateTime.Now > (DueDate != null ? DueDate : DateTime.MaxValue);
            }
        }
    }
}

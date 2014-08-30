using System;

namespace OneSolutionV3.Domain.DTO.Debt
{
    public class DebtCreateViewModel
    {
        public double Amount { get; set; }
        public bool IsMyDebt { get; set; }
        public DateTime DebtDate { get; set; }
        public DateTime ? DueDate { get; set; }
        public string Comment { get; set; }
        public int ContactId { get; set; }        
        public int AccountId { get; set; }
        public string ContactName { get; set; }
    }
}

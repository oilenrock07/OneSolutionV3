using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Domain.DTO.Debt;
using System.Collections.Generic;

namespace OneSolutionV3.Service.Interface
{
    public interface IDebtPaymentRepository : IRepository<DebtPayment, int>
    {
        IEnumerable<DebtPaymentViewModel> GetDebtPayments(int debtId);
        double GetTotalPayment(int debtId);
    }
}

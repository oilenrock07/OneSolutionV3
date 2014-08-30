using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Debt;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class DebtPaymentRepository : Repository<DebtPayment, int> , IDebtPaymentRepository
    {
        public DebtPaymentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<DebtPaymentViewModel> GetDebtPayments(int debtId)
        {
            return _dbSet.Where(e => e.DebtId == debtId && !e.IsDeleted)
                   .Select(e => new DebtPaymentViewModel
                   {
                       Amount = e.Amount,
                       AccountName = e.Account.AccountName,
                       Comment = e.Comment,
                       DatePaid = e.DatePaid,
                       DebtPaymentId = e.DebtPaymentId
                   });
        }


        public double GetTotalPayment(int debtId)
        {
            return _dbSet.Where(e => e.DebtId == debtId && !e.IsDeleted)
                   .Select(e => e.Amount).ToList()  
                   .Sum(e => e);
        }
    }
}

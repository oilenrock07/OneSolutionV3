using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Debt;
using System.Linq;
using OneSolutionV3.Common.Utility;

namespace OneSolutionV3.Service.Repository
{
    public class DebtRepository : Repository<Debt, int> , IDebtRepository
    {
        private readonly IDebtPaymentRepository _debtPaymentRepository;

        public DebtRepository(IDatabaseFactory databaseFactory, IDebtPaymentRepository debtPaymentRepository)
            : base(databaseFactory)
        {
            _debtPaymentRepository = debtPaymentRepository;
        }

        public IEnumerable<DebtViewModel> GetDebts(int userId)
        {
            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                         .Select(e => new
                         {
                             AccountId = e.AccountId,
                             AccountName = e.Account.AccountName,
                             Amount = e.Amount,
                             Comment = e.Comment,
                             FirstName = e.Contact.FirstName,
                             LastName = e.Contact.LastName,
                             MiddleName = e.Contact.MiddleName,
                             DebtDate = e.DebtDate,
                             DebtId = e.DebtId,
                             DueDate = e.DueDate,
                             IsMyDebt = e.IsMyDebt,
                             Status = e.Status,
                         }).ToList()
                         .Select(e => new DebtViewModel
                         {
                             AccountId = e.AccountId,
                             AccountName = e.AccountName,
                             Amount = e.Amount,
                             Comment = e.Comment,
                             ContactName = e.FirstName + " " + e.MiddleName + " " + e.LastName,
                             DebtDate = e.DebtDate,
                             DebtId = e.DebtId,
                             DueDate = e.DueDate,
                             IsMyDebt = e.IsMyDebt,
                             Payments = _debtPaymentRepository.GetDebtPayments(e.DebtId),
                             Status = e.Status
                         });
            
            return result;
        }
    }
}

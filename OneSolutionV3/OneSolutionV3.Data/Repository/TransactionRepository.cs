using OneSolutionV3.Infrastructure;
using OneSolutionV3.Service.Interface;
using OneSolutionV3.Domain.Models;
using System.Data.Objects;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Transaction;
using System;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class TransactionRepository : Repository<Transaction, int>, ITransactionRepository
    {
        public TransactionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }

        public IEnumerable<AmountAndDate> GetExpensePerDay(int userId, DateTime startDate, DateTime endDate)
        {
            startDate = Convert.ToDateTime(startDate.ToShortDateString());
            endDate = Convert.ToDateTime(endDate.ToShortDateString()).AddDays(1).AddMinutes(-1);

            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.Category.IsExpense &&  e.TransactionDate >= startDate && e.TransactionDate <= endDate)
                       .Select(e => new 
                       {
                           Amount = e.Amount,
                           TransactionDate = EntityFunctions.TruncateTime(e.TransactionDate)
                       })
                       .GroupBy(e => e.TransactionDate)
                       .Select(e => new AmountAndDate
                       {
                           Amount = e.Sum(y => y.Amount),
                           TransactionDate = e.Key
                       });

            return result;
        }


        public IEnumerable<AmountAndDate> GetExpensePerMonth(int userId, DateTime startDate, DateTime endDate)
        {
            startDate = Convert.ToDateTime(startDate.ToShortDateString());
            endDate = Convert.ToDateTime(endDate.ToShortDateString()).AddDays(1).AddMinutes(-1);

            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.Category.IsExpense && e.TransactionDate >= startDate && e.TransactionDate <= endDate)
                       .Select(e => new 
                       {
                           Amount = e.Amount,
                           TransactionDate = EntityFunctions.AddDays(EntityFunctions.TruncateTime(e.TransactionDate), -(e.TransactionDate.Day - 1))
                       })
                       .GroupBy(e => e.TransactionDate)
                       .Select(e => new AmountAndDate
                       {
                           Amount = e.Sum(y => y.Amount),
                           TransactionDate = e.Key
                       });

            return result;
        }


        public IEnumerable<ReportTransactionViewModel> GetExpenseIncome(int userId, DateTime startDate, DateTime endDate)
        {
            startDate = Convert.ToDateTime(startDate.ToShortDateString());
            endDate = Convert.ToDateTime(endDate.ToShortDateString()).AddDays(1).AddMinutes(-1);

            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.TransactionDate >= startDate && e.TransactionDate <= endDate)
                         .Select(e => new ReportTransactionViewModel
                         {
                             AccountName = e.Account.AccountName,
                             Amount = e.Amount,
                             IsExpense = e.Category.IsExpense,
                             CategoryName = e.Category.CategoryName,
                             Remarks = e.Remarks,
                             TransactionDate = e.TransactionDate,
                             TransactionId = e.TransactionId
                         });

            return result;
        }

        public IEnumerable<ReportTransactionViewModel> GetExpenseIncome(int userId, DateTime startDate, DateTime endDate, bool isExpense)
        {
            startDate = Convert.ToDateTime(startDate.ToShortDateString());
            endDate = Convert.ToDateTime(endDate.ToShortDateString()).AddDays(1).AddMinutes(-1);

            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.TransactionDate >= startDate && e.TransactionDate <= endDate && e.Category.IsExpense == isExpense)
                         .Select(e => new ReportTransactionViewModel
                         {
                             AccountName = e.Account.AccountName,
                             Amount = e.Amount,
                             IsExpense = e.Category.IsExpense,
                             CategoryName = e.Category.CategoryName,
                             Remarks = e.Remarks,
                             TransactionDate = e.TransactionDate,
                             TransactionId = e.TransactionId
                         });

            return result;
        }


        public IEnumerable<TransactionUpdate> GetTransactionForUpdate(int userId, IEnumerable<int> transactionId)
        {
            return _dbSet.Where(e => e.UserId == userId && transactionId.Contains(e.TransactionId))
                   .Select(e => new TransactionUpdate
                   {
                       AccountId = e.AccountId,
                       Amount = e.Amount,
                       IsExpense = e.Category.IsExpense,
                       TransactionId = e.TransactionId
                   });
        }
    }
}

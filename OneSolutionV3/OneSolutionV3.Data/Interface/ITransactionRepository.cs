using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Transaction;
using System;

namespace OneSolutionV3.Service.Interface
{
    public interface ITransactionRepository : IRepository<Transaction, int>
    {
        IEnumerable<AmountAndDate> GetExpensePerDay(int userId, DateTime startDate, DateTime endDate);
        IEnumerable<AmountAndDate> GetExpensePerMonth(int userId, DateTime startDate, DateTime endDate);
        IEnumerable<ReportTransactionViewModel> GetExpenseIncome(int userId, DateTime startDate, DateTime endDate);
        IEnumerable<ReportTransactionViewModel> GetExpenseIncome(int userId, DateTime startDate, DateTime endDate, bool isExpense);
        IEnumerable<TransactionUpdate> GetTransactionForUpdate(int userId, IEnumerable<int> transactionId);
    }
}

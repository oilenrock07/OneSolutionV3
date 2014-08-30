using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LinqToExcel;
using OneSolutionV3.Common.MobileData.Interface;
using OneSolutionV3.Common.Model;


namespace OneSolutionV3.Common.MobileData.Implementation
{
    public class DailyExpenseManager : IMobileData
    {
        private static string DEMSheetName = ConfigurationManager.AppSettings["DEMSheetName"];

        public List<ImportTransaction> ReadContent(string fullName, DateTime startDate, DateTime endDate)
        {
            var excel = new ExcelQueryFactory(fullName);
            excel.AddMapping<ImportTransaction>(x => x.AccountType, "Payment Mode");
            excel.AddMapping<ImportTransaction>(x => x.Remarks, "Description");
            excel.AddMapping<ImportTransaction>(x => x.TransactionType, "Transaction Type");
            excel.AddMapping<ImportTransaction>(x => x.Amount, "Cost (₱)");

            var result = excel.Worksheet<ImportTransaction>(DEMSheetName)
                        .Select(e => new ImportTransaction
                            {
                                AccountType = e.AccountType != "Cash" ? e.AccountType : "Cash In Hand",
                                Amount = e.TransactionType == "Expense" ? -e.Amount : e.Amount,
                                Category = e.Category,
                                Date = e.Date,
                                Remarks = e.Remarks,
                                TransactionType = e.TransactionType
                            }).Where(e => e.Date >= startDate && e.Date <= endDate).ToList();
                               
            return result;
        }
    }
}

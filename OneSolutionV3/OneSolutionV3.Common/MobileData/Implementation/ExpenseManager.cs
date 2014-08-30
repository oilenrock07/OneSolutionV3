using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LinqToExcel;
using OneSolutionV3.Common.MobileData.Interface;
using OneSolutionV3.Common.Model;

namespace OneSolutionV3.Common.MobileData.Implementation
{
    public class ExpenseManager : IMobileData
    {
        private static string EMSheetName = ConfigurationManager.AppSettings["EMSheetName"];

        List<ImportTransaction> IMobileData.ReadContent(string fullName, DateTime startDate, DateTime endDate)
        {
            List<ImportTransaction> transactions = new List<ImportTransaction>();

            var excel = new ExcelQueryFactory(fullName);
            var result = excel.WorksheetNoHeader(EMSheetName).Where(e => e[0].Cast<DateTime>() >= startDate && e[0].Cast<DateTime>() <= endDate).ToList();

            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    ImportTransaction import = new ImportTransaction
                    {
                        AccountType = "Cash In Hand",
                        Amount = -Convert.ToDouble(item[2]),
                        Category = item[1],
                        Remarks = item[4],
                        Date = Convert.ToDateTime(item[0])
                    };

                    transactions.Add(import);
                }
            }
            
            return transactions;
        }
    }
}

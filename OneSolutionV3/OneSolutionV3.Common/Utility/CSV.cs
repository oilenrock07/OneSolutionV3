using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Configuration;
using OneSolutionV3.Common.Model;

namespace OneSolutionV3.Common.Utility
{
    public static class CSV
    {
        private static string CSVPath = ConfigurationManager.AppSettings["CSVPath"];

        public static void CreateTemplate(int userId)
        {
            string destinationPath = CSVPath + @"\" + userId.ToString();
            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);

            File.Copy(CSVPath + "CSVTemplate.csv", destinationPath + @"\CSVTemplate.csv", true);
        }

        public static List<ImportTransaction> ReadCSVContent(string csvFullName)
        {
            List<ImportTransaction> transactions = new List<ImportTransaction>();

            using (CsvFileReader reader = new CsvFileReader(csvFullName))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    ImportTransaction newTransaction = new ImportTransaction
                    {
                        Category = row[0],
                        AccountType = row[1],
                        TransactionType = row[2],
                        Amount = Convert.ToDouble(row[3]),
                        Date = Convert.ToDateTime(row[4]),
                        Remarks = row[5]
                    };

                    transactions.Add(newTransaction);
                }
            }

            return transactions;
        }

        public static List<ImportTransaction> ReadFinanciusData(string CSVFullName)
        {
            List<ImportTransaction> transactions = new List<ImportTransaction>();

            //using (CsvFileReader reader = new CsvFileReader(CSVFullName))
            //{
            //    CsvRow row = new CsvRow();
            //    while (reader.ReadRow(row))
            //    {
            //        //ImportTransaction newTransaction = new ImportTransaction
            //        //{
            //        //    Category = row[0],
            //        //    AccountType = row[1],
            //        //    TransactionType = row[2],
            //        //    Amount = Convert.ToDouble(row[3]),
            //        //    Date = Convert.ToDateTime(row[4]),
            //        //    Remarks = row[5]
            //        //};

            //        //transactions.Add(newTransaction);
            //    }
            //}

            return transactions;
        }
    }

    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    public class CsvFileWriter : StreamWriter
    {
        public CsvFileWriter(Stream stream)
            : base(stream)
        {
        }

        public CsvFileWriter(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Writes a single row to a CSV file.
        /// </summary>
        /// <param name="row">The row to be written</param>
        public void WriteRow(CsvRow row)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in row)
            {
                // Add separator if this isn't the first value
                if (!firstColumn)
                    builder.Append(',');
                // Implement special handling for values that contain comma or quote
                // Enclose in quotes and double up any double quotes
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                else
                    builder.Append(value);
                firstColumn = false;
            }
            row.LineText = builder.ToString();
            WriteLine(row.LineText);
        }
    }

    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }
}
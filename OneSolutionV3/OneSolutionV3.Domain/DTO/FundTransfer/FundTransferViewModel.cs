using System;

namespace OneSolutionV3.Domain.DTO.FundTransfer
{
    public class FundTransferViewModel
    {
        public int FundTransferId { get; set; }
        public string FromAccountName { get; set; }
        public string ToAccountName { get; set; }
        public string Comment { get; set; }

        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }

        public double Amount { get; set; }
        public DateTime DateTransfer { get; set; }
        public string TimeTransfer { get; set; }
    }
}

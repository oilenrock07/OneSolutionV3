using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneSolutionV3.Domain.DTO.Account
{
    public class AccountDisplayViewModel
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}

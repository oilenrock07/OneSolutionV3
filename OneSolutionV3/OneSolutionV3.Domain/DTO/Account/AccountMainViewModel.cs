
namespace OneSolutionV3.Domain.DTO.Account
{
    public class AccountMainViewModel
    {
        public int AccountId { get; set; }
        public int AccountType { get; set; }
        public string AccountTypeName { get; set; }

        public double Amount { get; set; }

        public int BankId { get; set; }
        public string BankName { get; set; }
    }
}

using OneSolutionV3.Domain.DTO.Account;

namespace OneSolutionV3.Domain.DTO.Bank
{
    public class BankAccountsViewModel
    {
        //Banks
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }

        public AccountDisplayViewModel Account { get; set; }
    }
}

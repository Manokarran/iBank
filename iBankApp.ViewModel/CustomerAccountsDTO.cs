using System.Collections.Generic;

namespace iBankApp.ViewModel
{
    public class CustomerAccountsDTO
    {
        public CustomerAccountsDTO()
        {
            Accounts = new HashSet<AccountDTO>();
        }

        public long CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerContact { get; set; }


        public ICollection<AccountDTO> Accounts { get; set; } = new List<AccountDTO>();
    }
}
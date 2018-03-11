using System;
using System.Collections.Generic;

namespace iBankApp.ViewModel
{
    public class CustomerTransactionDTO
    {
        public CustomerTransactionDTO() => Transactions = new HashSet<TransactionDTO>();

        public long CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerContact { get; set; }
        public long AccountId { get; set; }
        public decimal? AccountBalance { get; set; }
        public long TransactionId { get; set; }
        public decimal? TransactionAmount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionCode { get; set; }

        public ICollection<TransactionDTO> Transactions { get; set; } = new List<TransactionDTO>();

    }
}

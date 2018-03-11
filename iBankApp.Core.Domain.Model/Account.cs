using System;
using System.Collections.Generic;

namespace iBankApp.Core.Domain.Model
{
    public class Account
    {
        public Account()
        {
            AccountTransaction = new HashSet<AccountTransaction>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal? Balance { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public ICollection<AccountTransaction> AccountTransaction { get; set; } = new List<AccountTransaction>();
    }
}
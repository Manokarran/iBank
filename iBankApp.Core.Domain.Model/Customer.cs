using System;
using System.Collections.Generic;

namespace iBankApp.Core.Domain.Model
{
    public class Customer
    {
        public Customer() => Account = new HashSet<Account>();

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactInformation { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public ICollection<Account> Account { get; set; } = new List<Account>();
    }
}

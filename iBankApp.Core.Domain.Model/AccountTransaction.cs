using System;

namespace iBankApp.Core.Domain.Model
{
    public class AccountTransaction
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string TransactionCode { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
using System;

namespace iBankApp.ViewModel
{
    public class TransactionDTO
    {
        public long Id { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string TransactionCode { get; set; }
    }
}
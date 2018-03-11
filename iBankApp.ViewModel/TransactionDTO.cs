using System;

namespace iBankApp.ViewModel
{
    public abstract class TransactionDTO
    {
        public long Id { get; set; }
         public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string TransactionCode { get; set; }
      
    }
}

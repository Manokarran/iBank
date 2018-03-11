namespace iBankApp.ViewModel
{
    public abstract class AccountDTO
    {
        public long Id { get; set; }       
        public decimal? Balance { get; set; }
    }
}

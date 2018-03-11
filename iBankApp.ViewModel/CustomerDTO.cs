namespace iBankApp.ViewModel
{
    public abstract class CustomerDTO
    {
        public long CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerContact { get; set; }        

    }
}

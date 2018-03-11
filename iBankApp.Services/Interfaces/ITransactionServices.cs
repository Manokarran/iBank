using iBankApp.ViewModel;
using System.Collections.Generic;

namespace iBankApp.Services.Interfaces
{
    public interface ITransactionServices
    {
        IEnumerable<CustomerTransactionDTO> GetCustomerTransactions(long Id);
    }
}

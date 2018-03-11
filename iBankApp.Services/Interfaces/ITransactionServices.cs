using System.Collections.Generic;
using iBankApp.ViewModel;

namespace iBankApp.Services.Interfaces
{
    public interface ITransactionServices
    {
        IEnumerable<CustomerTransactionDTO> GetCustomerTransactions(long Id);
    }
}
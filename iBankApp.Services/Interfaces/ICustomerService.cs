using System.Collections.Generic;
using iBankApp.ViewModel;

namespace iBankApp.Services.Interfaces
{
    public interface ICustomerServices
    {
        IEnumerable<CustomerDTO> GetCustomers();
        IEnumerable<CustomerDTO> GetCustomer(long Id);
        IEnumerable<CustomerAccountsDTO> GetCustomerWithAccounts(long Id);
    }
}
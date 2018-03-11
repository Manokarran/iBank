using iBankApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace iBankApp.Services.Interfaces
{
    public interface ICustomerServices
    {
        IEnumerable<CustomerDTO> GetCustomers();
        IEnumerable<CustomerDTO> GetCustomer(long Id);
        IEnumerable<CustomerAccountsDTO> GetCustomerWithAccounts(long Id);
        
    }
}

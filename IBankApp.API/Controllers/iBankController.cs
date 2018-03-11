using iBankApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IBankApp.API.Controllers
{
    /// <summary>
    /// iBank Controller - exposes all basic API in the form of JSON
    /// </summary>
    [Produces("application/json")]
    [Route("api/iBank")]
    public class iBankController : Controller
    {
        //
        //TODO: Exception and invalid requests have to be handled and logged
        //

        private readonly ICustomerServices _customerServices;
        private readonly ITransactionServices _transactionServices;

        public iBankController(ICustomerServices customerServices, ITransactionServices transactionServices)
        {
            _customerServices = customerServices;
            _transactionServices = transactionServices;
        }

        [HttpGet("customer")]
        public IActionResult Get() => Ok(_customerServices.GetCustomers());

        [HttpGet("customer/{Id}")]
        public IActionResult Get(long Id) => Ok(_customerServices.GetCustomer(Id));

        [HttpGet("customer/{Id}/IncludeAccounts")]
        public IActionResult IncludeAccounts(long Id) => Ok(_customerServices.GetCustomerWithAccounts(Id));

        [HttpGet("customer/{Id}/IncludeTransactions")]
        public IActionResult IncludeTransactions(long Id) => Ok(_transactionServices.GetCustomerTransactions(Id));

    }
}
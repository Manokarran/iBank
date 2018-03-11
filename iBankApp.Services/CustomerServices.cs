using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using iBankApp.Core.Domain.Model;
using iBankApp.Interfaces.Data;
using iBankApp.Services.Interfaces;
using iBankApp.ViewModel;

namespace iBankApp.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerServices(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(_customerRepository.GetReadOnly());
        }

        public IEnumerable<CustomerDTO> GetCustomer(long Id)
        {
            Expression<Func<Customer, bool>> expression = x => x.Id == Id;
            return _mapper.Map<IEnumerable<CustomerDTO>>(_customerRepository.GetReadOnly(expression));
        }

        public IEnumerable<CustomerAccountsDTO> GetCustomerWithAccounts(long Id)
        {
            Expression<Func<Customer, bool>> expression = x => x.Id == Id;
            Expression<Func<Customer, object>>[] navigationProperties = {c => c.Account};

            return _mapper.Map<IEnumerable<CustomerAccountsDTO>>(
                _customerRepository.GetReadOnly(expression, navigationProperties));
        }
    }
}
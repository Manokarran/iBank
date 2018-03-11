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
    public class TransactionService : ITransactionServices
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Account> _transactionRepository;

        public TransactionService(IGenericRepository<Account> transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public IEnumerable<CustomerTransactionDTO> GetCustomerTransactions(long Id)
        {
            Expression<Func<Account, bool>> expression = x => x.CustomerId == Id;
            Expression<Func<Account, object>>[] navigationProperties =
                {c => c.AccountTransaction, d => d.Customer};

            return _mapper.Map<IEnumerable<CustomerTransactionDTO>>(
                _transactionRepository.GetReadOnly(expression, navigationProperties));
        }
    }
}
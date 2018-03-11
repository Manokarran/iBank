using System;
using System.Collections.Generic;
using System.Linq;
using iBankApp.Core.Domain.Model;
using iBankApp.Core.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace iBankApp.Data.Setup
{
    public class iBankDataSetup
    {
        private readonly iBankAppContext _dbcontext;

        private readonly DbSet<Customer> _dbset;

        public iBankDataSetup(iBankAppContext context)
        {
            
            _dbcontext = context;
            _dbset = _dbcontext.Set<Customer>();
        }

        public void SetUpData()
        {

            if (_dbset.Any()) return;


            _dbcontext.TransactionType.AddRange(AddTransactionTypes());
            _dbcontext.Customer.AddRange(AddCustomer());
            _dbcontext.Account.AddRange(AddAccount());
            _dbcontext.AccountTransaction.AddRange(AddTransaction());

            _dbcontext.SaveChanges();

        }

        private static readonly Random random = new Random();

        private static Decimal RandomBalanceBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return (decimal) (minValue + (next * (maxValue - minValue)));
        }

        private IEnumerable<TransactionType> AddTransactionTypes()
        {
            var transactionType = new List<TransactionType>
            {
                new TransactionType()
                {
                    Code = "DEBT",
                    Description  = "Debits",

                },
                 new TransactionType()
                {
                    Code = "CRDT",
                    Description  = "Credits",

                },
                   new TransactionType()
                {
                    Code = "OTHER",
                    Description  = "Other Transactions",

                }
            };
            return transactionType;
        }

        private IEnumerable<Customer> AddCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "Manokaran",
                    LastName = "Chidambaram",
                    ContactInformation = "Sydney"
                },
                new Customer()
                {
                    Id = 2,
                    FirstName = "Jayesh",
                    LastName = "Nair",
                    ContactInformation = "Ashfield"
                },
                 new Customer()
                {
                    Id = 3,
                    FirstName = "Hari",
                    LastName = "Haran",
                    ContactInformation = "Parramatta"
                }
            };

            return customers;
            
        }

        private IEnumerable<Account> AddAccount()
        {
            var accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    CustomerId=1,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                new Account()
                {
                    Id = 2,
                    CustomerId=1,
                   Balance = RandomBalanceBetween(200, 100000)
                },
                new Account {
                    Id = 3,
                    CustomerId=1,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                new Account {
                    Id = 4,
                    CustomerId=2,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                  new Account {
                    Id = 5,
                    CustomerId=2,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                    new Account {
                    Id = 6,
                    CustomerId=2,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                new Account {
                    Id = 7,
                    CustomerId=3,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                new Account {
                    Id = 8,
                    CustomerId=3,
                    Balance = RandomBalanceBetween(200, 100000)
                },
                new Account {
                    Id = 9,
                    CustomerId=3,
                    Balance = RandomBalanceBetween(200, 100000)
                },
            };

            return accounts;

        }

     

        private IEnumerable<AccountTransaction> AddTransaction()
        {
            var accountTransaction = new List<AccountTransaction>
            {
                new AccountTransaction()
                {
                    Id = 1,
                    AccountId = 1,
                  
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "CRDT"                   
                },
                new AccountTransaction()
                {
                    Id = 2,
                    AccountId = 1,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 3,
                    AccountId = 2,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "OTHER"
                },
                new AccountTransaction()
                {
                    Id = 4,
                    AccountId = 3,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 5,
                    AccountId = 3,
                  
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 6,
                    AccountId = 4,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 7,
                    AccountId = 5,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "CRDT"
                },
                new AccountTransaction()
                {
                    Id = 8,
                    AccountId = 6,
                    
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 9,
                    AccountId = 7,
                  
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "CRDT"
                },
                new AccountTransaction()
                {
                    Id = 10,
                    AccountId = 8,
                    
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "OTHER"
                },
                new AccountTransaction()
                {
                    Id = 11,
                    AccountId = 9,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "CRDT"
                },
                new AccountTransaction()
                {
                    Id = 12,
                    AccountId = 7,
                  
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 13,
                    AccountId = 8,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 14,
                    AccountId = 9,
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "DEBT"
                },
                new AccountTransaction()
                {
                    Id = 15,
                    AccountId = 6,
                   
                    Amount = RandomBalanceBetween(10, 300),
                    Date = DateTime.UtcNow.AddDays(new Random().Next(90)),
                    TransactionCode = "CRDT"
                }
            };

            return accountTransaction;

        }

    }
}

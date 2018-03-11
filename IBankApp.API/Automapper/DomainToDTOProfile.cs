using AutoMapper;
using iBankApp.Core.Domain.Model;
using iBankApp.ViewModel;
using System;

namespace iBankApp.API.Automapper
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.CustomerContact, opt => opt.MapFrom(src => src.ContactInformation))
                .ReverseMap();

            CreateMap<Account, CustomerTransactionDTO>()
               .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                   .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                   .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                   .ForMember(dest => dest.CustomerContact, opt => opt.MapFrom(src => src.Customer.ContactInformation))
                   .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.AccountBalance, opt => opt.MapFrom(src => src.Balance))
                   .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.AccountTransaction))
               .ReverseMap();


            CreateMap<Customer, CustomerAccountsDTO>()              
                  .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.CustomerContact, opt => opt.MapFrom(src => src.ContactInformation))
                  .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src => src.Account))
              .ReverseMap();
           
        }

        protected DomainToDTOProfile(string profileName) : base(profileName)
        {
        }

        protected DomainToDTOProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
        {
        }
    }
}

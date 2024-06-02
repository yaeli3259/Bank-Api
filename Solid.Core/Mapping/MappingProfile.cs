using AutoMapper;
using Solid.Core.DTOs;
using Solid.Core.Models;
using System.Data;

namespace Solid.Core.Mapping
{
    public class MappingProfile : Profile
    {     
        public MappingProfile()
        {
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<OfficialBank, OfficialBankDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using System.Data;
using bank_api_project.Models;
using Solid.Core.Models;

namespace bank_api_project.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<BankAccountPostModel, BankAccount>()
                   .ForMember(dest => dest.withdrawals, opt => opt.Ignore())
                   .ForMember(dest => dest.Id, opt => opt.Ignore())
                   .ForMember(dest => dest.deposits, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<CostumerPostModel, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<BankOperationPostModel, BankOperation>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<OfficialBankPostModel, OfficialBank>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
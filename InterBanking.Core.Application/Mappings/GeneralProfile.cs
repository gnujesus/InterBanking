using AutoMapper;
using InterBanking.Core.Application.ViewModels.Account;
using InterBanking.Core.Application.ViewModels.User;
using InterBanking.Core.Domain.Entities;

namespace InterBanking.Core.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<Account, SaveAccountViewModel>().ReverseMap();
        CreateMap<Account, AccountViewModel>().ReverseMap();
    }
}
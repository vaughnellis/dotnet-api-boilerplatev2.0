using AutoMapper;
using DotnetApiBoilerplatev2._0.Core.DTO.In;
using DotnetApiBoilerplatev2._0.Core.DTO.Out;
using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Authentication
            CreateMap<Accounts, PostLoginRequestByBasicCredentialDTO>()
               .ForMember(dto => dto.Email, obj => obj.MapFrom(x => x.Email))
               .ForMember(dto => dto.Password, obj => obj.MapFrom(x => x.Password));

            CreateMap<Accounts, PostLoginResponseByBasicCredentialDTO>()
                .ForMember(dto => dto.AccountId, obj => obj.MapFrom(x => x.Id))
                .ForMember(dto => dto.Name, obj => obj.MapFrom(x => x.Name))
                .ForMember(dto => dto.Email, obj => obj.MapFrom(x => x.Email))
                .ForMember(dto => dto.IsActive, obj => obj.MapFrom(x => x.IsActive));
        }
    }
}
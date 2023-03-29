using AutoMapper;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Domain.Entities.Mansion;
using LocalUserBO = MansionRentBackend.Application.BusinessObjects.LocalUser;
using LocalUserEO = MansionRentBackend.Domain.Entities.LocalUser;
using RegistrationBO = MansionRentBackend.Application.BusinessObjects.Registration;

namespace MansionRentBackend.Application.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<MansionEO, MansionBO>()
                .ReverseMap();

            CreateMap<LocalUserBO, LocalUserEO>()
                .ReverseMap();

            CreateMap<LocalUserEO, RegistrationBO>()
                .ReverseMap();

            CreateMap<LocalUserEO, LocalUserBO>()
                .ReverseMap();
        }
    }
}
using AutoMapper;
using VillaBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using LoginBO = MansionRentBackend.Application.BusinessObjects.Login;
using RegistrationBO = MansionRentBackend.Application.BusinessObjects.Registration;
using MansionRentBackend.API.Model;

namespace MansionRentBackend.API.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<VillaCreateModel, VillaBO>()
                .ReverseMap();

            CreateMap<VillaBO, VillaEditModel>()
                .ReverseMap();

            CreateMap<LoginRequestModel, LoginBO>()
                .ReverseMap();

            CreateMap<RegistrationRequestModel, RegistrationBO>()
                .ReverseMap();
        }
    }
}
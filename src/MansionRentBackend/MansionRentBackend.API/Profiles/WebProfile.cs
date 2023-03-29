using AutoMapper;
using MansionRentBackend.API.DTOs;
using LoginBO = MansionRentBackend.Application.BusinessObjects.Login;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using RegistrationBO = MansionRentBackend.Application.BusinessObjects.Registration;

namespace MansionRentBackend.API.Profiles;

public class WebProfile : Profile
{
    public WebProfile()
    {
        CreateMap<MansionCreateDto, MansionBO>()
            .ReverseMap();

        CreateMap<MansionBO, MansionEditDto>()
            .ReverseMap();

        CreateMap<LoginRequestDto, LoginBO>()
            .ReverseMap();

        CreateMap<RegistrationRequestDto, RegistrationBO>()
            .ReverseMap();
    }
}
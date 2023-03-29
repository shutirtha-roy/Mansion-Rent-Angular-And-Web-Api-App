using MansionRentBackend.Application.BusinessObjects;

namespace MansionRentBackend.API.DTOs;

public class LoginResponseDto : BaseDto
{
    public LocalUser User { get; set; }
    public string Token { get; set; }
}
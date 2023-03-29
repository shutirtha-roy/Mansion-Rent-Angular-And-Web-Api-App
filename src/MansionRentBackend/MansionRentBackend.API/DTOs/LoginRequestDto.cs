namespace MansionRentBackend.API.DTOs;

public class LoginRequestDto : BaseDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
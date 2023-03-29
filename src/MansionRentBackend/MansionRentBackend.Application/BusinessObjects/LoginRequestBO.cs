namespace MansionRentBackend.Application.BusinessObjects;

public class LoginRequestBO
{
    public LocalUser User { get; set; }
    public string Token { get; set; }
}
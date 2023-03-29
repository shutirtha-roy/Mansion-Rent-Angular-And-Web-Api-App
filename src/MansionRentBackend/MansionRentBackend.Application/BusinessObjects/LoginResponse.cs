namespace MansionRentBackend.Application.BusinessObjects
{
    public class LoginResponse
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
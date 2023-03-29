using MansionRentBackend.API.Model;
using MansionRentBackend.Application.BusinessObjects;

namespace MagicVilla_VillaAPI.Model
{
    public class LoginResponseModel : BaseModel
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
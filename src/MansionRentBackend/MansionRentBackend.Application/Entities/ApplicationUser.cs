using Microsoft.AspNetCore.Identity;

namespace MansionRentBackend.Application.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public List<Mansion> Mansions { get; set; }
    }
}

namespace MansionRentBackend.Domain.Entities;
public sealed class LocalUser : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
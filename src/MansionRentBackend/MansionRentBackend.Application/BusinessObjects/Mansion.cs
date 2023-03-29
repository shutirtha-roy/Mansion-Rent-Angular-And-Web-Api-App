namespace MansionRentBackend.Application.BusinessObjects;

public sealed class Mansion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Details { get; set; }
    public double Rate { get; set; }
    public int Sqft { get; set; }
    public int Occupancy { get; set; }
    public string? Base64Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
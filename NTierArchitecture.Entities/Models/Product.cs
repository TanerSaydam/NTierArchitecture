using NTierArchitecture.Entities.Abstractions;

namespace NTierArchitecture.Entities.Models;
public sealed class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }    
}

namespace NTierArchitecture.Entities.Models;
public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }    
}

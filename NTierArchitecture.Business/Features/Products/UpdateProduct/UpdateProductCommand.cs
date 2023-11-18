using MediatR;

namespace NTierArchitecture.Business.Features.Products.UpdateProduct;
public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId) : IRequest;

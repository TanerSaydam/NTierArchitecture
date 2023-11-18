using MediatR;

namespace NTierArchitecture.Business.Features.Products.RemoveProductById;
public sealed record RemoveProductByIdCommand(
    Guid Id): IRequest;

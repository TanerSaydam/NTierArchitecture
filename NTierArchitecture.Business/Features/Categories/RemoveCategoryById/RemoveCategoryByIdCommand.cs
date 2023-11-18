using MediatR;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategoryById;
public sealed record RemoveCategoryByIdCommand(
    Guid Id): IRequest;

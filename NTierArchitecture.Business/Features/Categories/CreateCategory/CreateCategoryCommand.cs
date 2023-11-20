using ErrorOr;
using MediatR;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    string Name) : IRequest<ErrorOr<Unit>>;

using MediatR;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Categories.GetCategories;
public sealed record GetCategoriesQuery(): IRequest<List<Category>>;

using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.CategoryFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.CategoryFeature.Queries.GetCategories;

public record GetCategoriesQuery(): IQuery<BaseResponse<List<CategoryDto>>>;
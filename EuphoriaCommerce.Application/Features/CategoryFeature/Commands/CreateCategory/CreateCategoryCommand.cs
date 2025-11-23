using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.CategoryFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.CategoryFeature.Commands.CreateCategory;

public record CreateCategoryCommand(CreateCategoryDto CategoryDto): ICommand<BaseResponse<string>>;
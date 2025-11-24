namespace EuphoriaCommerce.Application.Features.BadgesFeature.DTOs;

public record CreateBadgeDto(string Name, string Color, Guid ProductId);
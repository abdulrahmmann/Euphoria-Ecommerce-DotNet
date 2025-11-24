namespace EuphoriaCommerce.Application.Features.BadgesFeature.DTOs;

public record BadgeDto(string Name, string Color, Guid ProductId, string ProductName);
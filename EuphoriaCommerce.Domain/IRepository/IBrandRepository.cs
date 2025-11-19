using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IBrandRepository
{
    Task<List<Brand>> GetBrands(CancellationToken cancellationToken);
    
    Task AddBrand(Brand category, CancellationToken cancellationToken);
}
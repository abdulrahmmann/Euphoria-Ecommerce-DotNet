using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace EuphoriaCommerce.Application.Cloudinary;

public class CloudinaryService(CloudinaryDotNet.Cloudinary cloudinary)
{
    public async Task<string?> UploadProfileImageAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return null;
        
        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Folder = "profile-images" 
        };

        var result = await cloudinary.UploadAsync(uploadParams);

        return result.SecureUrl.AbsoluteUri;
    }

    public async Task<string?> UploadCategoryImageAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0) return null;

        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Folder = "category-images"
        };

        var result = await cloudinary.UploadAsync(uploadParams);

        return result.SecureUrl.AbsoluteUri;
    }
    
    public async Task<string?> UploadBrandImageAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0) return null;

        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Folder = "brand-images"
        };

        var result = await cloudinary.UploadAsync(uploadParams);

        return result.SecureUrl.AbsoluteUri;
    }
    
    public async Task<string?> UploadProductImageAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0) return null;

        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Folder = "product-images"
        };

        var result = await cloudinary.UploadAsync(uploadParams);

        return result.SecureUrl.AbsoluteUri;
    }
}
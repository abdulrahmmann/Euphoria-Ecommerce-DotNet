using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Helpers;

public class CloudinaryService(Cloudinary cloudinary)
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
}
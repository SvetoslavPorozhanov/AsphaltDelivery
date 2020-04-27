namespace AsphaltDelivery.Services
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file);
    }
}

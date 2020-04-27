namespace AsphaltDelivery.Services.Data.Pictures
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;

    public interface IPictureService
    {
        Task ChangePictureAsync(Picture picture);

        Task<Picture> GetPictureAsync();
    }
}

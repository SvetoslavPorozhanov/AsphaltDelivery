namespace AsphaltDelivery.Web.ViewModels.Pictures
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class PictureViewModel : IMapFrom<Picture>
    {
        public string Uri { get; set; }

        // public IFormFile ProfilePicture { get; set; }
    }
}

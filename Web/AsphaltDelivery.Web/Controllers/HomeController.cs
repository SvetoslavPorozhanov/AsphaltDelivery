namespace AsphaltDelivery.Web.Controllers
{
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using AsphaltDelivery.Services;
    using AsphaltDelivery.Services.Data.Pictures;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels;
    using AsphaltDelivery.Web.ViewModels.Pictures;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly Cloudinary cloudinary;
        private readonly IPictureService pictureService;
        private readonly ICloudinaryService cloudinaryService;

        public HomeController(Cloudinary cloudinary, IPictureService pictureService, ICloudinaryService cloudinaryService)
        {
            this.cloudinary = cloudinary;
            this.pictureService = pictureService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var picture = await this.pictureService.GetPictureAsync();
            var pictureViewModel = AutoMapperConfig.MapperInstance.Map<PictureViewModel>(picture);
            return this.View(pictureViewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        public IActionResult NotFound()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file/*PictureViewModel pictureViewModel*/)
        {
            var picture = await this.pictureService.GetPictureAsync();
            var uri = picture.Uri;
            uri = Regex.Replace(uri, "http://res.cloudinary.com/asphaltdelivery/image/upload/", string.Empty);

            string pattern = @"\/(?<name>[^.]+)[.]";

            Match match = Regex.Match(uri, pattern);

            var publicId = string.Empty;

            if (match.Success)
            {
                publicId = match.Groups["name"].Value;
            }

            var deletionParams = new DeletionParams(publicId);

            if (publicId != "Truck_kjh3ry")
            {
                await this.cloudinary.DestroyAsync(deletionParams);
            }

            //var file = pictureViewModel.ProfilePicture;
            var result = await this.cloudinaryService.UploadAsync(this.cloudinary, file);
            picture = await this.pictureService.GetPictureAsync();
            picture.Uri = result;
            await this.pictureService.ChangePictureAsync(picture);

            return this.RedirectToAction("Index", "Home");
        }
    }
}

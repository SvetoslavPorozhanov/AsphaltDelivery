namespace AsphaltDelivery.Services.Data.Pictures
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;

    public class PictureService : IPictureService
    {
        private const string EmptyPictureErrorMessage = "Picture Uri is empty.";
        private const string InvalidPictureErrorMessage = "Picture with ID: 1 does not exist.";
        private readonly ApplicationDbContext context;

        public PictureService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task ChangePictureAsync(Picture picture)
        {
            if (string.IsNullOrWhiteSpace(picture.Uri))
            {
                throw new ArgumentNullException(EmptyPictureErrorMessage);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task<Picture> GetPictureAsync()
        {
            var picture = await this.context.Pictures.FindAsync(1);

            if (picture == null)
            {
                throw new ArgumentNullException(InvalidPictureErrorMessage);
            }

            return picture;
        }
    }
}

namespace AsphaltDelivery.Web.ViewModels.AsphaltMixtures
{
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Mapping;

    public class AsphaltMixtureDeleteViewModel : IMapFrom<DeleteAsphaltMixtureServiceModel>
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}

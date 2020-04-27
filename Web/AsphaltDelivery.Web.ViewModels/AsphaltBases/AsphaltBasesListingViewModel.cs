namespace AsphaltDelivery.Web.ViewModels.AsphaltBases
{
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;

    public class AsphaltBasesListingViewModel : IMapFrom<AllAsphaltBasesServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

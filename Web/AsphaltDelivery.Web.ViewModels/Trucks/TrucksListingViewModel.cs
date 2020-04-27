namespace AsphaltDelivery.Web.ViewModels.Trucks
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Mapping;

    public class TrucksListingViewModel : IMapFrom<AllTrucksServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
    }
}

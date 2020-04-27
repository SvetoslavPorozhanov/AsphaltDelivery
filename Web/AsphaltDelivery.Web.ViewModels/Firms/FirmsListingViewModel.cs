namespace AsphaltDelivery.Web.ViewModels.Firms
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;

    public class FirmsListingViewModel : IMapFrom<AllFirmsServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
